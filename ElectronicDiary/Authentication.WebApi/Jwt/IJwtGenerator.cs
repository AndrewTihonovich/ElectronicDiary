using Authentication.WebApi.User;

namespace Authentication.WebApi.Jwt
{
   public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
