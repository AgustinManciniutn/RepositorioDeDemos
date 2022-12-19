using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Architecture
{
    public class ProductAttribute
    {

        public int Id { get; set; }
        [ForeignKey("ProductId")]
        public string ProductId { get; set; }
        [ForeignKey("AttributeId")]
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        public string? Value { get; set; }
        public Product Product { get; set; }
        public Attr Attribute { get; set; }
    }
}
