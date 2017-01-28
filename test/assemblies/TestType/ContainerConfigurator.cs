using ContainerAbstraction.Core.Configure;
using ContainerAbstraction.Core.Test.Assemblies.TestContract;

namespace ContainerAbstraction.Core.Test.Assemblies.TestType
{
    public class ContainerConfigurator : IContainerConfigurator
    {
        public void Configure(IContainerConfiguration configuration)
        {
            configuration.Register<ITestContract, TestType>();
            configuration.Register<ITestContract>(new TestType());
        }
    }
}
