namespace Wings
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using StructureMap;

    /// <summary>
    /// StructureMap based filter provider that enhances the built in attribute based filter provider to use DI.
    /// </summary>
    public class StructureMapFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        /// <summary>
        /// StructureMap container.
        /// </summary>
        private readonly IContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="StructureMapFilterAttributeFilterProvider"/> class.
        /// </summary>
        /// <param name="containerIns">The container.</param>
        public StructureMapFilterAttributeFilterProvider(IContainer containerIns)
        {
            container = containerIns;
        }

        /// <summary>
        /// Gets the collection of controller attributes.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>
        /// A collection of controller attributes.
        /// </returns>
        protected override IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<FilterAttribute> attributes = base.GetControllerAttributes(controllerContext, actionDescriptor);
            foreach (FilterAttribute attribute in attributes)
            {
                container.BuildUp(attribute);
            }

            return attributes;
        }

        /// <summary>
        /// Gets the collection of custom action attributes.
        /// </summary>
        /// <param name="controllerContext">The controller context.</param>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>
        /// A collection of custom action attributes.
        /// </returns>
        protected override IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            IEnumerable<FilterAttribute> attributes = base.GetActionAttributes(controllerContext, actionDescriptor);
            foreach (FilterAttribute attribute in attributes)
            {
                container.BuildUp(attribute);
            }

            return attributes;
        }
    }
}