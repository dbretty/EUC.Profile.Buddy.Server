using Microsoft.AspNetCore.Identity;
using EUC.Profile.Buddy.Web.Repositories.Entities;

namespace EUC.Profile.Buddy.Web.Models
{
    public static class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "Administrator", "HelpDesk", "Reader" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);

                if (!roleExists)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var email = "admin@eucprofilebuddy.com";
            var password = "SuperSecretPassword.123";

            if (userManager.FindByEmailAsync(email).Result == null)
            {
                ApplicationUser user = new()
                {
                    Email = email,
                    UserName = email,
                };

                IdentityResult result = userManager.CreateAsync(user, password).Result;

                if (result == IdentityResult.Success)
                {
                    userManager.AddToRoleAsync(user, role: "Administrator").Wait();
                }
            }
        }
    }
}
