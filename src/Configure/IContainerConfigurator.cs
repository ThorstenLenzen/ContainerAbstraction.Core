namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Holds the DI container configuration for a module.
    /// </summary>
    public interface IContainerConfigurator
    {
        /// <summary>
        /// Configures the DI container for a module.
        /// </summary>
        /// <returns>The DI configuration for a module.</returns>
        void Configure(IContainerConfiguration configuration);
    }
}
