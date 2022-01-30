using Microsoft.AspNetCore.Identity;

namespace Authentication.WebApi.User
{
    public class AppUser : IdentityUser
    {
        public string Login { get; set; }
        public string UserLastName { get; set; }
    }
}
