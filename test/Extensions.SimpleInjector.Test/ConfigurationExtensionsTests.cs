using ContainerAbstraction.Core.Configure;
using ContainerAbstraction.Core.Test.Assemblies.TestContract;
using ContainerAbstraction.Core.Test.Assemblies.TestType;
using SimpleInjector;
using Xunit;

namespace ContainerAbstraction.Core.Extensions.SimpleInjector.Test
{
    public class ConfigurationExtensionsTests
    {
        [Fact]
        public void UseSimpleInjector_WithTypeContainerConfiguration_ConfiguresSimpleInjector() 
        {
            // Arrange
            var configuration = new ContainerConfiguration();
            configuration.TypeConfigurationItems.Add(new TypeConfigurationItem
            {
                ServiceType = typeof(ITestContract),
                ImplementationType = typeof(TestType),
                Lifecycle = Lifecycle.Singleton
            });

            // Act
            var container = new Container();
            container.Configure(configuration);
            var instance = container.GetInstance<ITestContract>();

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void UseSimpleInjector_WithInstanceContainerConfiguration_ConfiguresSimpleInjector()
        {
            // Arrange
            var configuration = new ContainerConfiguration();
            configuration.InstanceConfigurationItems.Add(new InstanceConfigurationItem
            {
                ServiceType = typeof(ITestContract),
                Instance = new TestType(),
                Lifecycle = Lifecycle.Singleton
            });

            // Act
            var container = new Container();
            container.Configure(configuration);
            var instance = container.GetInstance<ITestContract>();

            // Assert
            Assert.NotNull(instance);
        }
    }
}
