using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;


namespace BookStoreSite.Models
{
    public class UserRoleInitializer
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<DefaultUser>>();

                string[] roleNames = { "Admin", "User" };

                IdentityResult roleResult;

                foreach (var role in roleNames)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role);

                    if (!roleExists)
                    {
                        roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                var email = "admin@site.com";
                var password = "Qwerty123!";

                if (userManager.FindByEmailAsync(email).Result == null)
                {
                    DefaultUser user = new()
                    {
                        Email = email,
                        UserName = email,
                        FirstName = "Admin",
                        LastName = "Adminsson",
                        Address = "Adstreet 3",
                        City = "Big City",
                        ZipCode = "12345"
                    };

                    IdentityResult result = userManager.CreateAsync(user, password).Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }
            }
        }
    }
}
