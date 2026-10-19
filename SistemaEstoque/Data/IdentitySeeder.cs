using Microsoft.AspNetCore.Identity;

namespace SistemaEstoque.Data
{
    public class IdentitySeeder
    {
        public static async Task CriarRolesEUsuariosAdminAs(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // 1. Cria as Roles no banco (Admin e Estoquista)
            string[] roles = { "Admin", "Estoquista" };

            foreach (string role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // 2. Cria o usuário Estoquista
            var estoquistaEmail = "estoquista@gmail.com";
            var estoquistaUser = await userManager.FindByEmailAsync(estoquistaEmail);

            if (estoquistaUser == null)
            {
                var user = new IdentityUser
                {
                    UserName = estoquistaEmail,
                    Email = estoquistaEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "Estoquista@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Estoquista");
                }
            }

            // 3. Cria o usuário Admin (Para o "Admin" que estava só na role funcionar!)
            var adminEmail = "admin@gmail.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                var admin = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var resultAdmin = await userManager.CreateAsync(admin, "Admin@123");
                if (resultAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }

    }
}
