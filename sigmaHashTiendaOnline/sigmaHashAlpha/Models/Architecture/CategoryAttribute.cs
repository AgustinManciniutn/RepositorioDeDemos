using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Models.Architecture
{
    public class CategoryAttribute
    {

        public int CategoryId {get;set;}
        public string AttributeId { get; set; }
        public Category Category { get; set; }
        public Attr Attribute { get; set; }

    }
}
