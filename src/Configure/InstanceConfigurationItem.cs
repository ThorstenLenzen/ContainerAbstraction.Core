using System;

namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Holds all Information a DI container needs to to register an instance.
    /// </summary>
    public class InstanceConfigurationItem
    {
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public object Instance { get; set; }

        /// <summary>
        /// Gets or sets the life cycle.
        /// </summary>
        /// <value>
        /// The life cycle.
        /// </value>
        public Lifecycle Lifecycle { get; set; }
    }
}