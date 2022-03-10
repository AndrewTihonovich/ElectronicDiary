using Authentication.WebApi.User;
using Authentication.WebApi.User.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Redis;
using System;
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
            UserInfo cashUser = default;
            try
            {
                cashUser = await _cache.GetCashItemAsync<UserInfo>(userId);
            }
            catch (Exception getEx)
            {
                _logger.LogError(getEx.Message);
            }

            if (cashUser is null)
            {
                var user = await _repository.FindByEmail(userId);
                var result = new UserInfo { UserLogin = user.UserName };
                try
                {
                    await _cache.SetCashItemAsync<UserInfo>(userId, result);
                }
                catch (Exception setEx)
                {
                    _logger.LogError(setEx.Message);
                    return result;
                }
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
