using MediatrDemo.Data.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatrDemo.MongoDb.Entities
{
    public  class MongoDbEntity : IEntity
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public virtual Guid Id { get; set; } = Guid.NewGuid();
    }

    public class MongoDbEntity<TKey> :  IEntity<TKey>
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        [BsonElement(Order = 0)]
        public virtual TKey Id { get; set; }
    }

}
