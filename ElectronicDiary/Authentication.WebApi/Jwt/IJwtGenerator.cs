using Authentication.WebApi.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.Jwt
{
   public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
