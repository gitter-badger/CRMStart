using System.Security.Claims;
using System.Threading.Tasks;
using CRMStart.Core.Domain.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

namespace CRMStart.Web.Framework.Infrastructure.Security
{
    public class CRMStartSignInManager : SignInManager<CrmStartUser, string>
    {
        public CRMStartSignInManager(CRMStartUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(CrmStartUser user)
        {
            return user.GenerateUserIdentityAsync((CRMStartUserManager) UserManager);
        }

        public static CRMStartSignInManager Create(IdentityFactoryOptions<CRMStartSignInManager> options,
            IOwinContext context)
        {
            return new CRMStartSignInManager(context.GetUserManager<CRMStartUserManager>(), context.Authentication);
        }
    }
}