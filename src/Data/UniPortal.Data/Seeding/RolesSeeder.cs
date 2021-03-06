﻿namespace UniPortal.Data.Seeding
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Seeding.Contracts;

    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(UniPortalDbContext dbContext, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, "Guest");
            await SeedRoleAsync(roleManager, "Student");
            await SeedRoleAsync(roleManager, "Teacher");
            await SeedRoleAsync(roleManager, "Administrator");
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}