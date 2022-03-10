using Authentication.WebApi.Jwt;
using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Authentication.WebApi.Validations.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Authentication.WebApi.Controllers
{
    public class AuthenController : ControllerBase
    {
        private readonly ILogger<AuthenController> _logger;

        private readonly IUserRepository _repository;
        private readonly IJwtGenerator _jwt;
        private readonly IAuthValidator _authValidator;

        public AuthenController(ILogger<AuthenController> logger, IUserRepository repository, IJwtGenerator jwt, IAuthValidator authValidator)
        {
            _logger = logger;
            _repository = repository;
            _jwt = jwt;
            _authValidator = authValidator;
        }

        [AllowAnonymous]
        [Route("api/login")]
        [HttpPost]
        public async Task<AutUser> LoginAsync([FromBody] UserLogin request) 
        {
            string token = null;

            await _authValidator.LoginValidator(request);

            var user = await _repository.FindByEmail(request.Email);

            if (user != null)
            {
                if (await _repository.CheckPassword(user, request.Password))
                {
                    token = await _jwt.CreateToken(user);
                }

                var autUser = new AutUser { DisplayName = user.Email, Token = token };

                return autUser;
            }

            throw new Exception("Login Error");
        }

        [AllowAnonymous]
        [Route("api/registration")]
        [HttpPost]
        public async Task<AutUser> RegistrationAsync([FromBody] UserRegistration request)
        {
            await _authValidator.RegistrationValidator(request);
            var registrationUser = await _repository.Create(request);

            var token = await _jwt.CreateToken(registrationUser);
            var autUser = new AutUser { DisplayName = request.Email, Token = token };

            return autUser;
        }
    }
}
