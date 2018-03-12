namespace Domin.Common
{
    /// <summary>
    /// The unit of work interface.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The commit method.
        /// </summary>
        void Commit();

        /// <summary>
        /// The rollback method.
        /// </summary>
        void Rollback();
    }
}
