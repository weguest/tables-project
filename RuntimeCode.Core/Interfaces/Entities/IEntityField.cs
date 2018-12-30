using RuntimeCode.Core.Interfaces.Entities.Enums;

namespace RuntimeCode.Core.Interfaces.Entities
{
    public interface IEntityField : IEntityBase<string>
    {
        string Label { get; set; }
        string Html { get; set; }
        string JavaScript { get; set; }
        string Code { get; set; }
        string Format { get; set; }
        EnumFieldType FieldType { get; set; }
    }
}