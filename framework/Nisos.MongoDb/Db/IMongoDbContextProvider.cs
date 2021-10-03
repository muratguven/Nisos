namespace Nisos.MongoDb.Db
{
    public interface IMongoDbContextProvider<TMongoDbContext>
        where TMongoDbContext:IMongoDbContext
    {
        TMongoDbContext GetDbContext();
       
    }
}
