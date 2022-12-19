using System.Collections.Generic;

namespace sigmaHashAlpha.Infrastructure.Roles
{
    public class UserRole
    {
        public string Email { get; set; } = String.Empty ;
        public List<string> Roles { get; set; } = new List<string>();

     
    }
}
