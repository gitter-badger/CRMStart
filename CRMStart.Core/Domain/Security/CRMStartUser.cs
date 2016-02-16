using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CRMStart.Core.Domain.KnowledgeBase;
using CRMStart.Core.Domain.Support;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRMStart.Core.Domain.Security
{
    public class CrmStartUser : IdentityUser
    {
        public virtual IList<PreviousPassword> PreviousUserPasswords { get; set; } = new List<PreviousPassword>();
        public virtual UserProfile UsersProfile { get; set; }


      


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<CrmStartUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}