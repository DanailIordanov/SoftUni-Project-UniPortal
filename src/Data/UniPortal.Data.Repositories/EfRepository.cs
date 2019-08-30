namespace UniPortal.Data.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models.Contracts;
    using UniPortal.Data.Repositories.Contracts;

    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IIdentifiableEntity
    {
        private UniPortalDbContext dbContext;
        private DbSet<TEntity> dbSet;

        public EfRepository(UniPortalDbContext context)
        {
            this.DbContext = context;
            this.DbSet = this.DbContext.Set<TEntity>();
        }

        protected UniPortalDbContext DbContext
        {
            get => this.dbContext;
            private set => this.dbContext = value ?? throw new ArgumentNullException(nameof(this.DbContext));
        }

        protected DbSet<TEntity> DbSet
        {
            get => this.dbSet;
            private set => this.dbSet = value;
        }

        public Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity);

        public void Delete(TEntity entity) => this.DbSet.Remove(entity);

        public void Dispose() => this.DbContext.Dispose();

        public IQueryable<TEntity> GetAll() => this.DbSet;

        public IQueryable<TEntity> GetAllAsNoTracking() => this.DbSet.AsNoTracking();

        public TEntity GetById(string id) => this.DbSet.Find(id);

        public Task<int> SaveChangesAsync() => this.DbContext.SaveChangesAsync();

        public void Update(TEntity entity)
        {
            var entry = this.DbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbContext.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }
    }
}
