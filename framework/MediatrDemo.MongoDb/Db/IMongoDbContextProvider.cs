using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Db
{
    public interface IMongoDbContextProvider<TMongoDbContext>
        where TMongoDbContext:IMongoDbContext
    {
        TMongoDbContext GetDbContext();
       
    }
}
