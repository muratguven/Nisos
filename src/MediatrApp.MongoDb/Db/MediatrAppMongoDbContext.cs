﻿using MediatrDemo.MongoDb.Db;
using MediatrDemo.MongoDb.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrApp.MongoDb.Db
{
    public class MediatrAppMongoDbContext : MongoDbContextBase
    {
        private IMongoDbSettings _dbSettings;
        private IMongoClient _client;
        private IMongoDatabase _database;
        
        public MediatrAppMongoDbContext(IMongoDbSettings dbSettings)
        {
            _dbSettings = dbSettings;
            _client = new MongoClient(dbSettings.ConnectionString);
            _database = _client.GetDatabase(_dbSettings.DatabaseName);
            InitializeDatabase(_database, _client);
        }

    }
}
