namespace Domin.Common
{
    using System;

    /// <summary>
    /// The base entity class.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets Created date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or sets Modified Date
        /// </summary>
        public DateTime Modified { get; set; }

        /// <summary>
        /// The flag for entity state. 
        /// </summary>
        /// <returns>True if the entity is new.</returns>
        public abstract bool IsTransient();
    }
}
