using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CRMStart.Core.Domain.Security
{
    public class CRMStartUserStore : UserStore<CrmStartUser>

    {
        public CRMStartUserStore(DbContext context)
            : base(context)

        {
        }

        public override async Task CreateAsync(CrmStartUser user)
        {
            await base.CreateAsync(user);

            await AddToPreviousPasswordsAsync(user, user.PasswordHash);
        }

        public Task AddToPreviousPasswordsAsync(CrmStartUser user, string password)
        {
            user.PreviousUserPasswords.Add(new PreviousPassword {UserId = user.Id, PasswordHash = password});

            return UpdateAsync(user);
        }
    }
}