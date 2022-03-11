using Authentication.WebApi.User;
using System.Threading.Tasks;

namespace Authentication.WebApi.Validations.Authentication
{
    public interface IAuthValidator
    {
        Task LoginValidator (UserLogin request);
        Task RegistrationValidator (UserRegistration request);
    }
}
