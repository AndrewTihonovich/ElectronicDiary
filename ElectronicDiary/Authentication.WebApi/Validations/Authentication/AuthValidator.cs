using Authentication.WebApi.User;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Authentication.WebApi.Validations.Authentication
{
    public class AuthValidator : IAuthValidator
    {
        public Task LoginValidator(UserLogin request)
        {
            if (!checkEmail(request.Email))
            {
                throw new Exception($"Email = {request.Email} is incorrect");
            }
            if (string.IsNullOrWhiteSpace(request.Password))
            {
                throw new ArgumentNullException("Password can not be null or empty");
            }
            return Task.CompletedTask;
        }

        public Task RegistrationValidator(UserRegistration request)
        {
            if (string.IsNullOrWhiteSpace(request.FirstName))
            {
                throw new ArgumentNullException("FirstName can not be null or empty");
            }
            if (string.IsNullOrWhiteSpace(request.LastName))
            {
                throw new ArgumentNullException("LastName can not be null or empty");
            }
            if (string.IsNullOrWhiteSpace(request.UserNameLogin))
            {
                throw new ArgumentNullException("UserNameLogin can not be null or empty");
            }
            if (!checkEmail(request.Email))
            {
                throw new Exception($"Email = {request.Email} is incorrect");
            }

            return Task.CompletedTask;
        }

        private bool checkEmail(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email.ToLower(), pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
