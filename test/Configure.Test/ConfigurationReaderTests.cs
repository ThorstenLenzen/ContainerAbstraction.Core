using Xunit;

namespace ContainerAbstraction.Core.Configure.Test
{
    public class ConfigurationReaderTests
    {
        [Fact]
        public void ConfigureContainer_ReadConfigFromAssembliesStaticallyAndDynamically_Works()
        {
            // Act
            var config = ConfigurationReader.Read();


            // Assert
            Assert.Equal(3, config.TypeConfigurationItems.Count);
            Assert.Equal(3, config.InstanceConfigurationItems.Count);
        }
    }
}
