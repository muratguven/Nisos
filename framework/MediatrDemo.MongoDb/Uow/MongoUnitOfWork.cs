using MediatrDemo.MongoDb.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Uow
{
    public class MongoUnitOfWork : IMongoUnitOfWork
    {
        private readonly IMongoDbContext _context;
        public MongoUnitOfWork(IMongoDbContext context)
        {
            _context = context;
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public bool SaveChanges()
        {
            var changingCount = _context.CommitChanges();
            return changingCount > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var changingCount = await _context.CommitChangesAsync();
            return changingCount > 0;
        }
    }
}
