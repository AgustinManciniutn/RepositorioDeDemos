using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Models.Products
{
    public class Miscellaneous : Product 
    {
        [DataType(DataType.MultilineText)]
        [DisplayName("Descripción")]
        public string? Description { get; set; }
    }
}
