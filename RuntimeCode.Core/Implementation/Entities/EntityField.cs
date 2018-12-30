using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RuntimeCode.Core.Interfaces.Entities;
using RuntimeCode.Core.Interfaces.Entities.Enums;

namespace RuntimeCode.Core.Implementation.Entities
{
    [Serializable]
    [BsonDiscriminator(Required = true)]
    [BsonKnownTypes(typeof(EntityField))]
    public class EntityField : EntityBase, IEntityField
    {
        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string Label { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string Html { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string JavaScript { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string Code { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public string Format { get; set; }

        [BsonDefaultValue("")]
        [BsonIgnoreIfDefault]
        public EnumFieldType FieldType { get; set; }
    }
}