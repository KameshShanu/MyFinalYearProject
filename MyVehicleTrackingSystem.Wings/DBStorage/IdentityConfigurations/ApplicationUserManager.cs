using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStorage.IdentityConfigurations
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public async Task<IdentityResult> ChangePasswordAsync(ApplicationUser appUser, string newPassword)
        {
            var store = this.Store as IUserPasswordStore<ApplicationUser>;
            if (store == null)
            {
                var errors = new string[]
                {
                    "Current UserStore doesn't implement IUserPasswordStore"
                };

                return await Task.FromResult(IdentityResult.Failed(errors));
            }

            var newPasswordHash = this.PasswordHasher.HashPassword(newPassword);

            await store.SetPasswordHashAsync(appUser, newPasswordHash);
            return await Task.FromResult(IdentityResult.Success);
        }
    }
}
