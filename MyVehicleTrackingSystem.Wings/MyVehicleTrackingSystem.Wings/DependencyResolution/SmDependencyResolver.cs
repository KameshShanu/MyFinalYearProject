namespace Wings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using StructureMap;

    public class SmDependencyResolver : IDependencyResolver
    {
        private readonly IContainer _container;

        public SmDependencyResolver(IContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            try
            {
                return serviceType.IsAbstract || serviceType.IsInterface
                         ? _container.TryGetInstance(serviceType)
                         : _container.GetInstance(serviceType);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Get service.
        /// </summary>
        /// <param name="serviceType">The type of the service.</param>
        /// <returns>An onbect.</returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.GetAllInstances(serviceType).Cast<object>();
        }
    }
}