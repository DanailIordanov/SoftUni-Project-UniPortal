namespace UniPortal.Data.Seeding.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(UniPortalDbContext dbContext, IServiceProvider serviceProvider);
    }
}
