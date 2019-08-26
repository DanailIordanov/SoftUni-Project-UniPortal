namespace UniPortal.Data.Repositories.Contracts
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models.Contracts;

    public interface IRepository<TEntity> : IDisposable
        where TEntity : IIdentifiableEntity
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(string id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
