using Authentication.WebApi.Jwt;
using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.Controllers
{
    public class AuthenController : ControllerBase
    {
        private readonly ILogger<AuthenController> _logger;

        private readonly IUserRepository _repository;
        private readonly IJwtGenerator _jwt;

        public AuthenController(ILogger<AuthenController> logger, IUserRepository repository, IJwtGenerator jwt)
        {
            _logger = logger;
            _repository = repository;
            _jwt = jwt;
        }

        [AllowAnonymous]
        [Route("api/login")]
        [HttpPost]
        public async Task<AutUser> LoginAsync([FromBody] UserLogin request) //Task<AutUser>
        {
            string token = null;

            var user = await _repository.FindByEmail(request.Email);

            if (user != null)
            {
                if (await _repository.CheckPassword(user, request.Password))
                {
                    token = _jwt.CreateToken(user);
                }

                var autUser = new AutUser { DisplayName = user.Login, Token = token };

                return autUser;
            }

            throw new Exception("Login Error");

            //RedirectToRoute("api/record");
        }

        [AllowAnonymous]
        [Route("api/registration")]
        [HttpPost]
        public async Task<AutUser> RegistrationAsync([FromBody] UserRegistration request)
        {
            var registrationUser = await _repository.Create(request);

            var token = _jwt.CreateToken(registrationUser);
            var autUser = new AutUser { DisplayName = request.Login, Token = token };

            return autUser;
        }
    }
}
