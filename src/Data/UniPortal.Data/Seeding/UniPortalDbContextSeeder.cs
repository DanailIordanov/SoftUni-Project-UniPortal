namespace UniPortal.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UniPortal.Data.Common;
    using UniPortal.Data.Seeding.Contracts;

    public class UniPortalDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(UniPortalDbContext dbContext, IServiceProvider serviceProvider)
        {
            Validator.ThrowIfNull(dbContext, nameof(dbContext));
            Validator.ThrowIfNull(serviceProvider, nameof(serviceProvider));

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
