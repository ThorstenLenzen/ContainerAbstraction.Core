using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ContainerAbstraction.Core.Configure
{
    /// <summary>
    /// Reads the DI configuration from all assemblies within the directory of the executing assembly.
    /// </summary>
    public static class ConfigurationReader
    {
        /// <summary>
        /// Reads the DI configuration from all assemblies within the directory of the executing assembly.
        /// </summary>
        /// <returns>The DI configuration from all assemblies within the directory of the executing assembly.</returns>
        /// <exception cref="DirectoryNotFoundException">
        /// The path of the executing assembly could not be found.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// The type has an IContainerConfiguration interface, but could not be created as such.
        /// </exception>
        public static IContainerConfiguration Read()
        {
            IContainerConfiguration configuration = new ContainerConfiguration();

            var path = AppContext.BaseDirectory;

            if (path == null)
                throw new DirectoryNotFoundException("The path of the executing assembly could not be found.");

            var assemblyFiles = Directory
                .GetFiles(path, "*.*", SearchOption.TopDirectoryOnly)
                .Where(s => s.EndsWith(".dll", StringComparison.OrdinalIgnoreCase));

            foreach (var dll in assemblyFiles)
            {
                var assembly = AssemblyLoadContext
                    .Default
                    .LoadFromAssemblyPath(dll);

                foreach (var type in assembly.GetTypes())
                {
                    foreach (var intrfc in type.GetTypeInfo().ImplementedInterfaces)
                    {
                        if (intrfc.Name != "IContainerConfigurator")
                            continue;

                        var instance = Activator.CreateInstance(type) as IContainerConfigurator;

                        if (instance == null)
                            throw new InvalidOperationException(
                                "The type {0} has an IContainerConfiguration interface, but could not be created as such.");

                        instance.Configure(configuration);
                    }
                }
            }

            return configuration;
        }
    }
}
