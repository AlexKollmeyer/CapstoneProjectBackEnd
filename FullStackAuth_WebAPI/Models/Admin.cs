using Microsoft.AspNetCore.Identity;

namespace FullStackAuth_WebAPI.Models
{
    public class Admin : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
