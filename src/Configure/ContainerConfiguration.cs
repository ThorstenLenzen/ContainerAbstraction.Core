using System.Collections.Generic;

namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Contains methods, to configure a DI container.
    /// </summary>
    public class ContainerConfiguration : IContainerConfiguration
    {
        /// <summary>
        /// Gets the type configuration items, which have no special 
        /// instance creation within the DI container.
        /// </summary>
        /// <value>
        /// The type configuration items.
        /// </value>
        public IList<TypeConfigurationItem> TypeConfigurationItems { get; }

        /// <summary>
        /// Gets the instance configuration items, which have special 
        /// instance creation within the DI container.
        /// </summary>
        /// <value>
        /// The instance configuration items.
        /// </value>
        public IList<InstanceConfigurationItem> InstanceConfigurationItems { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerConfiguration"/> class.
        /// </summary>
        public ContainerConfiguration()
        {
            TypeConfigurationItems = new List<TypeConfigurationItem>();
            InstanceConfigurationItems = new List<InstanceConfigurationItem>();
        }

        /// <summary>
        /// Registers a type with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        public void Register<TService, TImplementation>()
        {
            Register<TService, TImplementation>(Lifecycle.Unspecified);
        }

        /// <summary>
        /// Registers a type with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="lifecycle">The life cycle.</param>
        public void Register<TService, TImplementation>(Lifecycle lifecycle)
        {
            TypeConfigurationItems.Add(new TypeConfigurationItem
            {
                ServiceType = typeof(TService),
                ImplementationType = typeof(TImplementation),
                Lifecycle = lifecycle
            });
        }

        /// <summary>
        /// Registers a type as an instance with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        public void Register<TService>(object instance)
        {
            Register<TService>(instance, Lifecycle.Unspecified);
        }

        /// <summary>
        /// Registers a type as an instance with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="lifecycle">The life cycle.</param>
        public void Register<TService>(object instance, Lifecycle lifecycle)
        {
            InstanceConfigurationItems.Add(new InstanceConfigurationItem
            {
                ServiceType = typeof(TService),
                Instance = instance,
                Lifecycle = lifecycle
            });
        }
    }
}
