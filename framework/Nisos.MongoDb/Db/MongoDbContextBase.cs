using Nisos.MongoDb.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.MongoDb.Db
{
    public  class MongoDbContextBase : IMongoDbContext
    {


        public IMongoClient Client { get; private set; }

        public IMongoDatabase Database { get; private set; }

        public IClientSessionHandle SessionHandle { get; private set; }

        private readonly List<Func<Task>> _commandsAsync;
        private readonly List<Action> _commands;

        public MongoDbContextBase()
        {
            _commandsAsync = new List<Func<Task>>();
            _commands = new List<Action>();
        }

        public virtual IMongoCollection<T> Collection<T>()
        {
            return Database.GetCollection<T>(GetCollectionName<T>());
        }

        protected virtual string GetCollectionName<T>()
        {
            //reflection using custom attribute
            return ((BsonCollectionAttribute) typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public virtual void InitializeDatabase(IMongoDatabase database, IMongoClient client)
        {
            Database = database;
            Client = client;
            //SessionHandle = client.Ses
        }


        public virtual IMongoCollection<T> GetCollection<T>()
        {
            return Database.GetCollection<T>(GetCollectionName<T>());
        }

        public void Dispose()
        {
            SessionHandle?.Dispose();
            GC.SuppressFinalize(this);
        }

        public void AddCommand(Func<Task> func) => _commandsAsync.Add(func);
        

        public void AddCommand(Action action) => _commands.Add(action);


        public virtual async Task<int> CommitChangesAsync()
        {
            ValidateClient();
            using (SessionHandle = await Client.StartSessionAsync())
            {
                SessionHandle.StartTransaction();

                var commandTasks = _commandsAsync.Select(c => c());
                await Task.WhenAll(commandTasks);
                await SessionHandle.CommitTransactionAsync();
            }

            return _commandsAsync.Count;
        }

        public int CommitChanges()
        {
            ValidateClient();
            using (SessionHandle = Client.StartSession())
            {
                SessionHandle.StartTransaction();
                foreach (Action act in _commands)
                {
                    act.Invoke();
                }

                SessionHandle.CommitTransaction();

            }
            return _commands.Count;
        }

        private void ValidateClient()
        {
            if (Client == null)
            {
                throw new ApplicationException($"Mongo client is null!");
            }
        }
    }
}
