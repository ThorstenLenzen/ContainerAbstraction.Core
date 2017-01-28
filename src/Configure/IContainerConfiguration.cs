using System.Collections.Generic;

namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Contains methods, to configure a DI container.
    /// </summary>
    public interface IContainerConfiguration
    {
        /// <summary>
        /// Gets the type configuration items, which have no special 
        /// instance creation within the DI container.
        /// </summary>
        /// <value>
        /// The type configuration items.
        /// </value>
        IList<TypeConfigurationItem> TypeConfigurationItems { get; }

        /// <summary>
        /// Gets the instance configuration items, which have special 
        /// instance creation within the DI container.
        /// </summary>
        /// <value>
        /// The instance configuration items.
        /// </value>
        IList<InstanceConfigurationItem> InstanceConfigurationItems { get; }

        /// <summary>
        /// Registers a type with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "Verify! TService is needed in order to fulfill the method purpose.")]
        void Register<TService, TImplementation>();

        /// <summary>
        /// Registers a type with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="lifecycle">The life cycle.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "Verify! TService is needed in order to fulfill the method purpose.")]
        void Register<TService, TImplementation>(Lifecycle lifecycle);

        /// <summary>
        /// Registers a type as an instance with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "Verify! TService is needed in order to fulfill the method purpose.")]
        void Register<TService>(object instance);

        /// <summary>
        /// Registers a type as an instance with the chosen DI framework.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="lifecycle">The life cycle.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design",
            "CA1004:GenericMethodsShouldProvideTypeParameter",
            Justification = "Verify! TService is needed in order to fulfill the method purpose.")]
        void Register<TService>(object instance, Lifecycle lifecycle);
    }
}