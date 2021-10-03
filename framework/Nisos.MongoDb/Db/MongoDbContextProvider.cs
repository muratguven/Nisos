using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nisos.MongoDb.Db
{
    public class MongoDbContextProvider<TMongoDbContext> : IMongoDbContextProvider<TMongoDbContext>
        where TMongoDbContext : IMongoDbContext
    {

        private IMongoDbContext _context;

        public MongoDbContextProvider(IMongoDbContext context)
        {
            _context = (TMongoDbContext)context;
        }

        public TMongoDbContext GetDbContext()
        {
            return (TMongoDbContext)_context;
        }

    }
}
