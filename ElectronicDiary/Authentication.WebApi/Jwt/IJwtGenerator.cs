using Authentication.WebApi.User;
using System.Threading.Tasks;

namespace Authentication.WebApi.Jwt
{
   public interface IJwtGenerator
    {
        Task<string> CreateToken(AppUser user);
    }
}
