using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Entities
{
    public class Entity : IEntity
    {
        public virtual Guid Id { get; set; }
    }

    public class Entity<TKey> : IEntity<TKey> 
    {
        public virtual TKey Id { get; set; }
    }
}
