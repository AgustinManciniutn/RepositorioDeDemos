using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Architecture
{
    public class Attr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttributeId { get; set; }
        [Required]
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        [Required]
        public string AttrName { get; set; }

        public bool HasOptions { get; set; } = false;
        public Category Category { get; set; }
        public List<AttributeOption> AttributeOptions { get; set; }
        public List<ProductAttribute> ProductAttributes { get; set; }
    }
}
