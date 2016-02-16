using System;
using System.Linq;
using System.Threading.Tasks;
using CRMStart.Core.Domain.Security;
using CRMStart.Core.Services.Security;
using CRMStart.Core.Validators.Security;
using CRMStart.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace CRMStart.Web.Framework.Infrastructure.Security
{
    public class CRMStartUserManager : UserManager<CrmStartUser>
    {
        private const int PasswordHistoryLimit = 5;

        public CRMStartUserManager(IUserStore<CrmStartUser> store)
            : base(store)
        {
        }


        public static CRMStartUserManager Create(IdentityFactoryOptions<CRMStartUserManager> options,
            IOwinContext context)
        {
            var appUserManager = new CRMStartUserManager(new CRMStartUserStore(context.Get<CrmStartObjectContext>()));


            appUserManager.UserValidator = new UserValidator<CrmStartUser>(appUserManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            //Password Logic
            appUserManager.PasswordValidator = new PasswordValidate
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = false,
                RequireLowercase = true,
                RequireUppercase = true
            };

            // Configure user lockout defaults
            appUserManager.UserLockoutEnabledByDefault = true;
            appUserManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            appUserManager.MaxFailedAccessAttemptsBeforeLockout = 5;


            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                appUserManager.UserTokenProvider =
                    new DataProtectorTokenProvider<CrmStartUser>(dataProtectionProvider.Create("ASP.NET Identity"))
                    {
                        //Code for email confirmation and reset password life time
                        TokenLifespan = TimeSpan.FromHours(6)
                    };
            }


            appUserManager.EmailService = new EmailService();
            appUserManager.SmsService = new SmsService();


            return appUserManager;
        }


        public override async Task<IdentityResult> ChangePasswordAsync(string userId, string currentPassword,
            string newPassword)
        {
            if (await IsPreviousPassword(userId, newPassword))
            {
                return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));
            }
            var result = await base.ChangePasswordAsync(userId, currentPassword, newPassword);
            if (result.Succeeded)
            {
                var store = Store as CRMStartUserStore;

                await
                    store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId),
                        PasswordHasher.HashPassword(newPassword));
            }
            return result;
        }


        public override async Task<IdentityResult> ResetPasswordAsync(string userId, string token, string newPassword)
        {
            if (await IsPreviousPassword(userId, newPassword))
            {
                return await Task.FromResult(IdentityResult.Failed("Cannot reuse old password"));
            }
            var result = await base.ResetPasswordAsync(userId, token, newPassword);
            if (result.Succeeded)
            {
                var store = Store as CRMStartUserStore;
                await
                    store.AddToPreviousPasswordsAsync(await FindByIdAsync(userId),
                        PasswordHasher.HashPassword(newPassword));
            }
            return result;
        }

        private async Task<bool> IsPreviousPassword(string userId, string newPassword)
        {
            var user = await FindByIdAsync(userId);

            if (user.PreviousUserPasswords.
                OrderByDescending(x => x.CreateDate)
                .Select(x => x.PasswordHash)
                .Take(PasswordHistoryLimit
                ).Any(x => PasswordHasher.VerifyHashedPassword(x, newPassword) != PasswordVerificationResult.Failed))
            {
                return true;
            }

            return false;
        }
    }
}