﻿namespace UniPortal.Data.Repositories.Contracts
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using UniPortal.Data.Models;

    public interface IRepository<TEntity> : IDisposable
        where TEntity : UniPortalEntity
    {
        IQueryable<TEntity> GetAll();

        TEntity GetById(string id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}