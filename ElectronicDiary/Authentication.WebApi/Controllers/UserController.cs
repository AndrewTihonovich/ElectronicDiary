using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Authentication.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _repository;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<UserInfo> GetUserInfo(string userId)
        {
            var user = await _repository.FindByEmail(userId);
            var result = new UserInfo { UserLogin = user.Login };

            return result;
        }

        [Authorize(Roles ="Admin")]
        [Route("all")]
        [HttpGet]
        public async Task<List<AppUser>> GetAllUsers()
        {
            var users = await _repository.GetAll();
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<string> DelUserById(string id)
        {
            return await _repository.DeleteById(id);
        }
    }
}
