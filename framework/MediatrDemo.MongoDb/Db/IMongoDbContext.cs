using MediatrDemo.Data.Db;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Db
{
    public interface IMongoDbContext :IMediatorDbContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<T> Collection<T>();

        IClientSessionHandle SessionHandle { get; }

        void AddCommand(Func<Task> func);
        void AddCommand(Action action);
        Task<int> CommitChangesAsync();

        int CommitChanges();

    }
}
