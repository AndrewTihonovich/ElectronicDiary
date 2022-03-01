using Authentication.WebApi.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AuthenticationContext _context;
        public UserRepository(UserManager<AppUser> userManager, AuthenticationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<AppUser> Create(UserRegistration user)
        {
            var appUser = new AppUser
            {
                Email = user.Email,
                Login = user.Login,
                PhoneNumber = user.Phone,
                UserName = user.FirstName,
                UserLastName = user.LastName
            };

            if (await IsFreeEmail(appUser.Email))
            {
                var identityResult = await _userManager.CreateAsync(appUser, user.Password);

                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, "User");
                    return appUser;
                }

                var error = identityResult.Errors.FirstOrDefault();
                throw new Exception($"Error create user {error.Description}");

            }
            throw new Exception("This Email use another user");
        }

        public async Task<AppUser> FindByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return user;
            }

            throw new Exception("User not found");
        }

        public async Task<bool> CheckPassword(AppUser user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        async Task<bool> IsFreeEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return false;
            }
            return true;
        }

        public async Task<List<AppUser>> GetAll()
        {
            var users = await _userManager.Users.ToListAsync();
            return users;
        }

        public async Task<string> DeleteById(string id)
        {
            var user = await FindByEmail(id);
            await _userManager.DeleteAsync(user);
            return user.Email;
        }
    }
}