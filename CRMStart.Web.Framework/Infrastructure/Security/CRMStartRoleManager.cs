using CRMStart.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CRMStart.Web.Framework.Infrastructure.Security
{
    public class CRMStartRoleManager : RoleManager<IdentityRole>
    {
        public CRMStartRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static CRMStartRoleManager Create(IdentityFactoryOptions<CRMStartRoleManager> options,
            IOwinContext context)
        {
            var appRoleManager =
                new CRMStartRoleManager(new RoleStore<IdentityRole>(context.Get<CrmStartObjectContext>()));

            return appRoleManager;
        }
    }
}