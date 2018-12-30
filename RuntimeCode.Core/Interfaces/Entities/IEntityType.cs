using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace RuntimeCode.Core.Interfaces.Entities
{
    public interface IEntityType : IEntityBase<string>
    {
        string Label { get; set; }
        string Html { get; set; }
        string JavaScript { get; set; }
        string Code { get; set; }
        IList<IEntityField> Fields { get; set; }
    }
}