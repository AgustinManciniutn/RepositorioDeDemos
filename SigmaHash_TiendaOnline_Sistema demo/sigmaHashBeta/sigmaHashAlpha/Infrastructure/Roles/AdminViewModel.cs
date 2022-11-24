using System.ComponentModel.DataAnnotations;

namespace sigmaHashAlpha.Infrastructure.Roles
{
    public class AdminViewModel
    {
        [Required]
        public string UserEmail { get; set; }
        public List<string> Roles { get; set; }
        public List<UserRole> RoledUsers { get; set; } = new List<UserRole>();


        public string PostUserEmail { get; set; }

        public bool Manager { get; set; }
        public bool Administrator { get; set; }
        public bool Assistant { get; set; }


    }
}
