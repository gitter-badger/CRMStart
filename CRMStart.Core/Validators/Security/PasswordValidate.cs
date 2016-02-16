using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace CRMStart.Core.Validators.Security
{
    public class PasswordValidate : PasswordValidator
    {
        public override async Task<IdentityResult> ValidateAsync(string password)
        {
            var result = await base.ValidateAsync(password);
            var errors = result.Errors.ToList();
            if (password.ToLower().Contains("abcdef") || password.Contains("123456"))
            {
                errors.Add("Password can not contain sequence of chars");
            }
            if (password.ToLower().Contains("password"))
            {
                errors.Add("Your password can not contain the word 'Password'");
            }

            if (errors.Count > 0)
            {
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}