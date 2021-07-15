﻿using MediatrDemo.MongoDb.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Db
{
    public abstract class MongoDbContextBase : IMongoDbContext
    {


        public IMongoClient Client { get; private set; }

        public IMongoDatabase Database { get; private set; }

        public IClientSessionHandle SessionHandle { get; private set; }

        public virtual IMongoCollection<T> Collection<T>()
        {
            return Database.GetCollection<T>(GetCollectionName<T>());
        }

        protected virtual string GetCollectionName<T>()
        {
            //reflection using custom attribute
            return ((BsonCollectionAttribute) typeof(T).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public virtual void InitializeDatabase(IMongoDatabase database, IMongoClient client, IClientSessionHandle sessionHandle)
        {
            Database = database;
            Client = client;
            SessionHandle = sessionHandle;
        }



    }
}
