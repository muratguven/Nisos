using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.Data.Entities
{
    public class Entity : IEntity
    {

    }

    public class Entity<TKey> : IEntity<TKey> where TKey : Type
    {
        public virtual TKey Id { get; set; }
    }
}
