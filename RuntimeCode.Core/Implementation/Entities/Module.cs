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
    [BsonKnownTypes(typeof(Module))]
    public class Module : EntityBase, IModule
    {
        public string Label { get;set; }
    }
}