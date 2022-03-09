using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Redis;
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
        private readonly IDistributedCache _cache;

        public UserController(ILogger<UserController> logger, IUserRepository repository, IDistributedCache cache)
        {
            _logger = logger;
            _repository = repository;
            _cache = cache;
        }

        [HttpGet]
        public async Task<UserInfo> GetUserInfo(string userId)
        {
            var cashUser = await _cache.GetCashItemAsync<UserInfo>(userId);
            if (cashUser is null)
            {
                var user = await _repository.FindByEmail(userId);
                var result = new UserInfo { UserLogin = user.Login };
                await _cache.SetCashItemAsync<UserInfo>(userId, result);

                return result;
            }
            return cashUser;
            
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
