namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Life cycles to configure the instance life cycles with a DI container.
    /// </summary>
    public enum Lifecycle
    {
        /// <summary>
        /// The life cycle is unspecified.
        /// </summary>
        Unspecified,

        /// <summary>
        /// The life cycle is transient.
        /// </summary>
        Transient,

        /// <summary>
        /// The life cycle is singleton.
        /// </summary>
        Singleton,

        /// <summary>
        /// The life cycle is scoped.
        /// </summary>
        Scoped,
    }
}