namespace sigmaHashAlpha.Models.Architecture.Schema;

public class SchemaMap
{
    public List<Category> Categories { get; set; }

    public List<Attr> Attributes { get; set; }

    public int? CategorySelectedId { get; set; }
    public int? AttributeSelectedId { get; set; }

    public Category Category { get; set; }
    public Attr Attribute { get; set; }
    public AttributeOption AttributeOption { get; set; } 
    public List<AttributeOption> Options { get; set; } = new();
}
