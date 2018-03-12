namespace DBStorage.Common
{
    using Domin.Common;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Represents the repository class
    /// </summary>
    /// <typeparam name="TEntity">The type of the domain entity.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// The reference to ProjectXContext instance.
        /// </summary>
        private WingsContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public Repository(WingsContext context)
        {
            _context = context;

        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get { return _context;  }
        }

        /// <summary>
        /// Gets the context.
        /// </summary>
        public WingsContext Context
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// Stores an instance of type {TEntity}.
        /// </summary>
        /// <param name="item">An instance of type {TEntity}.</param>
        public void Save(TEntity item)
        {
            this.Store(item);
            this.UnitOfWork.Commit();
        }

        /// <summary>
        /// Delete entity type TEntity.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The Deleted item.</returns>
        public TEntity Delete(TEntity item)
        {
            _context.Set<TEntity>().Attach(item);
            _context.Set<TEntity>().Remove(item);
            _context.Commit();
            return item;
        }

        /// <summary>
        /// Stores an instance of type {TEntity}.
        /// </summary>
        /// <param name="item">An instance of type {TEntity}.</param>
        public void Store(TEntity item)
        {
            _context.Entry<TEntity>(item).State = item.IsTransient() ? EntityState.Added : EntityState.Modified;
        }

        /// <summary>
        /// Retrieves an instance of type {TEntity} by the expression filter.
        /// </summary>
        /// <param name="filter">The expression filter.</param>
        /// <returns>An collection of type {TEntity}.</returns>
        public IEnumerable<TEntity> Retrieve(Expression<Func<TEntity, bool>> filter)
        {
            return _context.Set<TEntity>().Where(filter);
        }

        /// <summary>
        /// Retrieves an instance of type {TEntity} by primary key array.
        /// </summary>
        /// <param name="keyValues">The primary key array.</param>
        /// <returns>The instance of type {TEntity}.</returns>
        public TEntity RetrieveByKey(params object[] keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }
    }
}
