using System;

namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Holds all Information a DI container needs to to register a type.
    /// </summary>
    public class TypeConfigurationItem
    {
        /// <summary>
        /// Gets or sets the type of the service.
        /// </summary>
        /// <value>
        /// The type of the service.
        /// </value>
        public Type ServiceType { get; set; }

        /// <summary>
        /// Gets or sets the type of the implementation.
        /// </summary>
        /// <value>
        /// The type of the implementation.
        /// </value>
        public Type ImplementationType { get; set; }

        /// <summary>
        /// Gets or sets the life cycle.
        /// </summary>
        /// <value>
        /// The life cycle.
        /// </value>
        public Lifecycle Lifecycle { get; set; }
    }
}
