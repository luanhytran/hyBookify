﻿using hyBookify.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace hyBookify.Infrastructure.Repositories
{
    internal abstract class Repository<T>
        where T : Entity
    {
        protected readonly ApplicationDbContext DbContext;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<T?> GetByIdAsync(
            Guid id,
            CancellationToken cancellationToken = default)
        {
            return await DbContext
                .Set<T>()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public virtual void Add(T entity)
        {
            DbContext.Add(entity);
        }

        public virtual void Remove(T entity)
        {
            DbContext.Remove(entity);
        }
    }
}
