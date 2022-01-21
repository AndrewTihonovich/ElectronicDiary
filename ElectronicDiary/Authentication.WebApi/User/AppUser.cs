using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.User
{
    public class AppUser : IdentityUser
    {
        public string Login { get; set; }
        public string UserLastName { get; set; }

    }
}
