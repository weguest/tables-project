using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using RuntimeCode.Core.Interfaces.Entities;

namespace RuntimeCode.Core.Implementation.Entities
{
    [BsonIgnoreExtraElements(Inherited = true)]
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(EntityType), typeof(EntityField))]
    public class EntityBase : IEntityBase<string>
    {
        public EntityBase(){
            this.Created = DateTime.Now;
            this.Modified = DateTime.Now;
            this.Active = true;
        }

        [BsonIgnoreIfDefault]
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public bool Active { get; set; }
    }
}