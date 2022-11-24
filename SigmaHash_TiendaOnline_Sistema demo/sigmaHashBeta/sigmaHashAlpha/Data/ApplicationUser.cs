using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.Security.Claims;

namespace sigmaHashAlpha.Data
{
    public class ApplicationUser : IdentityUser
    {
       
        public string? CompleteName { get; set; }
        public string? DNI { get; set; }
        public string? Phone { get; set; }

        public bool OptInorOptOut { get; set; } = true;


    }
}
