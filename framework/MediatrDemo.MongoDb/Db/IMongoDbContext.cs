using MongoDB.Driver;

namespace MediatrDemo.MongoDb.Db
{
    public interface IMongoDbContext
    {
        IMongoClient Client { get; }
        IMongoDatabase Database { get; }
        IMongoCollection<T> Collection<T>();

        //IClientSessionHandle SessionHandle { get; }

    }
}
