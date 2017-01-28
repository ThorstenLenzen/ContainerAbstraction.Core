using Xunit;

namespace ContainerAbstraction.Core.Configure.Test
{
    public class ContainerConfigurationTests
    {
        private interface ITestType { }

        private class TestType : ITestType { }

        private interface ITestTypeWithLifeCycle { }

        private class TestTypeWithLifeCycle : ITestTypeWithLifeCycle { }

        private class TestTypeConfigurator : IContainerConfigurator
        {
            public void Configure(IContainerConfiguration configuration)
            {
                configuration.Register<ITestType, TestType>();
            }
        }

        private class TestTypeConfiguratorWithLifeCycle : IContainerConfigurator
        {
            public void Configure(IContainerConfiguration configuration)
            {
                configuration.Register<ITestType, TestType>(Lifecycle.Singleton);
            }
        }

        private class TestInstanceConfigurator : IContainerConfigurator
        {
            public void Configure(IContainerConfiguration configuration)
            {
                configuration.Register<ITestType>(new TestType());
            }
        }

        private class TestInstanceConfiguratorWithLifeCycle : IContainerConfigurator
        {
            public void Configure(IContainerConfiguration configuration)
            {
                configuration.Register<ITestType>(new TestType(), Lifecycle.Transient);
            }
        }

        [Fact]
        public void ConfigureContainer_RegisterSimpleType_StoresConfigInfoAsProvided() 
        {
            // Arrange
            IContainerConfigurator configurator = new TestTypeConfigurator();
            IContainerConfiguration config = new ContainerConfiguration();

            // Act
            configurator.Configure(config);

            // Assert
            Assert.Equal(1, config.TypeConfigurationItems.Count);
        }

        [Fact]
        public void ConfigureContainer_RegisterSimpleTypeWithLifecycle_StoresConfigInfoAsProvided()
        {
            // Arrange
            IContainerConfigurator configurator = new TestTypeConfiguratorWithLifeCycle();
            IContainerConfiguration config = new ContainerConfiguration();

            // Act
            configurator.Configure(config);

            // Assert
            Assert.Equal(1, config.TypeConfigurationItems.Count);
        }

        [Fact]
        public void ConfigureContainer_RegisterSimpleInstance_StoresConfigInfoAsProvided()
        {
            // Arrange
            IContainerConfigurator configurator = new TestInstanceConfigurator();
            IContainerConfiguration config = new ContainerConfiguration();

            // Act
            configurator.Configure(config);

            // Assert
            Assert.Equal(1, config.InstanceConfigurationItems.Count);
        }

        [Fact]
        public void ConfigureContainer_RegisterSimpleInstanceWithLifecylce_StoresConfigInfoAsProvided()
        {
            // Arrange
            IContainerConfigurator configurator = new TestInstanceConfiguratorWithLifeCycle();
            IContainerConfiguration config = new ContainerConfiguration();

            // Act
            configurator.Configure(config);

            // Assert
            Assert.Equal(1, config.InstanceConfigurationItems.Count);
        }
    }
}
