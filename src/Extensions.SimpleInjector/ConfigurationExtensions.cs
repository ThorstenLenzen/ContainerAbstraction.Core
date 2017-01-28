using System;
using System.Collections.Generic;
using ContainerAbstraction.Core.Configure;
using SimpleInjector;

namespace ContainerAbstraction.Core.Extensions.SimpleInjector
{
    /// <summary>
    /// Holds extensions for the configuration of the <see cref="Container"/> class.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Configures the a container using <see cref="IContainerConfigurator"/> implementations.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="containerConfiguration">The container configurators used to configure the <see cref="Container"/>.</param>
        /// <exception cref="ArgumentNullException">Throws, if the containerConfigurators parameter is null.</exception>
        public static void Configure(this Container container, IContainerConfiguration containerConfiguration)
        {
            if (containerConfiguration == null)
                throw new ArgumentNullException(nameof(containerConfiguration));

            RegisterTypes(container, containerConfiguration.TypeConfigurationItems);
            RegisterInstances(container, containerConfiguration.InstanceConfigurationItems);
        }

        private static void RegisterInstances(Container container, IList<InstanceConfigurationItem> instanceConfigurationItems)
        {
            if (instanceConfigurationItems == null)
                throw new ArgumentNullException(nameof(instanceConfigurationItems));

            foreach (var instanceConfigurationItem in instanceConfigurationItems)
            {
                var lifestyle = ConvertFromLifeCycle(instanceConfigurationItem.Lifecycle);

                container.Register(
                    instanceConfigurationItem.ServiceType,
                    () => instanceConfigurationItem.Instance,
                    lifestyle);
            }
        }

        private static void RegisterTypes(Container container, IList<TypeConfigurationItem> typeConfigurationItems)
        {
            if (typeConfigurationItems == null)
                throw new ArgumentNullException(nameof(typeConfigurationItems));

            foreach (var typeConfigurationItem in typeConfigurationItems)
            {
                var lifestyle = ConvertFromLifeCycle(typeConfigurationItem.Lifecycle);

                container.Register(
                    typeConfigurationItem.ServiceType,
                    typeConfigurationItem.ImplementationType,
                    lifestyle);
            }
        }

        private static Lifestyle ConvertFromLifeCycle(Lifecycle lifecycle)
        {
            switch (lifecycle)
            {
                case Lifecycle.Scoped:
                    return Lifestyle.Scoped;
                case Lifecycle.Singleton:
                    return Lifestyle.Singleton;
                default:
                    return Lifestyle.Transient;
            }
        }
    }
}
