namespace UniPortal.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using UniPortal.Data.Models;

    public class UniPortalDbContext : IdentityDbContext<UniPortalUser>
    {
        public UniPortalDbContext(DbContextOptions<UniPortalDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
