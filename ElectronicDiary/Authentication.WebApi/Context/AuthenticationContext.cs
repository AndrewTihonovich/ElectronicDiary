using Authentication.WebApi.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.WebApi.Context
{
    public class AuthenticationContext : IdentityDbContext<AppUser>
    {
        public AuthenticationContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost; DataBase=UserAuthentication_Test;Integrated Security=True");

        }
    }
}
