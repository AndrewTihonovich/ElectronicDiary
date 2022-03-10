using Authentication.WebApi.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.WebApi.Validations.Authentication
{
    public interface IAuthValidator
    {
        Task LoginValidator (UserLogin request);
        Task RegistrationValidator (UserRegistration request);
    }
}
