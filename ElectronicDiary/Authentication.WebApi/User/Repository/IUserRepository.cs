using System.Threading.Tasks;

namespace Authentication.WebApi.User.Repository
{
    public interface IUserRepository
    {
        Task<AppUser> Create(UserRegistration user);
        Task<AppUser> FindByEmail(string email);
        Task<bool> CheckPassword(AppUser user, string password);
    }
}
