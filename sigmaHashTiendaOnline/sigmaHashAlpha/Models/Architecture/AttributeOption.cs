using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Architecture
{
    public class AttributeOption
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttributeOptionId { get; set; }
        [ForeignKey("AttributeId")]
        public int AttributeId { get; set; }

        public string Option { get; set; } = string.Empty;

        public Attr Attribute { get; set; }
    }
}
