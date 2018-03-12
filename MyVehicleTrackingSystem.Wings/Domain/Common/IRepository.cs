namespace Domin.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    /// <summary>
    /// The repository interface.
    /// </summary>
    /// <typeparam name="TEntity">The entity type base entity.</typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Gets Unit of work.
        /// </summary>
        IUnitOfWork UnitOfWork
        {
            get;
        }

        /// <summary>
        /// The method for Delete item.
        /// </summary>
        /// <param name="item">The entity.</param>
        /// <returns>The deleted entity.</returns>
        TEntity Delete(TEntity item);

        /// <summary>
        /// The method for Store item.
        /// </summary>
        /// <param name="item">The entity.</param>
        void Store(TEntity item);

        /// <summary>
        /// The method for retrieve item.
        /// </summary>
        /// <param name="filter">The Filter function.</param>
        /// <returns>The collection of entity.</returns>
        IEnumerable<TEntity> Retrieve(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Retrieve an entity by its key.
        /// </summary>
        /// <param name="keyValues">The primary key of the entity.</param>
        /// <returns>An instance of <see cref="TEntity"/>.</returns>
        TEntity RetrieveByKey(params object[] keyValues);

        /// <summary>
        /// The save method for entity.
        /// </summary>
        /// <param name="item">The entity.</param>
        void Save(TEntity item);
    }
}
