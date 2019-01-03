using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using RuntimeCode.Core.Interfaces.Entities;

namespace RuntimeCode.Core.Implementation.Entities
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(EntityType))]
    public class EntityType : EntityBase, IEntityType
    {

        public EntityType() : base(){
            this.Fields = new List<IEntityField>();
        }

        public string Label { get; set; }
        public string Html { get; set; }
        public string JavaScript { get; set; }
        public string Code { get; set; }
        
        [BsonIgnoreIfNull]
        public IList<IEntityField> Fields { get; set; }

        [BsonIgnoreIfNull]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Module { get; set; }
    }
}