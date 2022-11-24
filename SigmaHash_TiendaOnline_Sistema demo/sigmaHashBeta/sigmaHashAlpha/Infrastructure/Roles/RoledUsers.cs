using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sigmaHashAlpha.Infrastructure.Roles
{
    public class RoledUsers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string UserId { get; set; }


    }
}
