namespace UnitOfWork.Repository
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public void Add(TEntity entity)
        {
            this.context.Set<TEntity>().Add(entity);
        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            this.context.Set<TEntity>().Remove(this.context.Set<TEntity>().FirstOrDefault(predicate));
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> predicate)
        {
            this.context.Set<TEntity>().RemoveRange(this.context.Set<TEntity>().Where(predicate));
        }

        public bool Any()
        {
            if (this.context.Set<TEntity>().Any())
            {
                return true;
            }

            return false;
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            if (this.context.Set<TEntity>().Any(predicate))
            {
                return true;
            }

            return false;
        }
        public TEntity FindFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this.context.Set<TEntity>().Where(predicate);
        }
        public IEnumerable<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> predicate)
        {
            return this.context.Set<TEntity>().Select(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.context.Set<TEntity>();
        }
    }
}
