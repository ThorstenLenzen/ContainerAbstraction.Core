# ContainerAbstraction.Core
The component abstracts a DI Container in order to avoid referencing it 
in every project. I like a system, in which you can configure your DI 
container in small steps per logical component. But you dn't want to have to 
reference your DI container of choice in every component. To change that 
later on would be a nightmare. So what to do? Fortunatley there is no 
problem in informatics you can't solve by adding a layer of abstraction 
:-). That is is what ContainerAbstraction is providuong you with. A nice 
clean way to configure your DI container without having to refere the 
real one!

## What assemblies to use where?
There are different assemblies in ContainerAbstraction. They are ment to 
support configuration and resolution of your DI container configuration.

### ContainerAbstraction.Configure
This assembly is the main configuration abstraction. Reference it in all 
assemblies, where you want to configure your DI Container of choice. You 
will also need to reference it in the assembly, where you resolve the 
abstract configuration and configure your real DI container.

### ContainerAbstraction.Extensions...
There are supposed to be different extensions to support a variety of DI 
containers. Actual, there is only an abstraction for SimpleInjector 
implemented, because it's my DI container of choice right now. So you 
will have to refenece the extension of your DI container in the assembly 
where you want to configure your real DI container. Usually that's the 
excecutble or the ASP.NET web project.

## Registering a Type with ContainerAbstraction
There are two interfaces to handle registering.

### IContainerConfigurator
This interface has to be implemented by the class, which holds the abstract 
configuration.

```csharp
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
```

### IContainerConfiguration
The IContainerConfiguration interface exposes methods to use for registering 
Types.

```csharp
/// <summary>
/// Contains methods, to configure a DI container.
/// </summary>
public interface IContainerConfiguration
{
    /// <summary>
    /// Registers a type with the chosen DI framework.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
    void Register<TService, TImplementation>();

    /// <summary>
    /// Registers a type with the chosen DI framework.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
    /// <param name="lifecycle">The life cycle.</param>
    void Register<TService, TImplementation>(Lifecycle lifecycle);

    /// <summary>
    /// Registers a type as an instance with the chosen DI framework.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <param name="instance">The instance.</param>
    void Register<TService>(object instance);

    /// <summary>
    /// Registers a type as an instance with the chosen DI framework.
    /// </summary>
    /// <typeparam name="TService">The type of the service.</typeparam>
    /// <param name="instance">The instance.</param>
    /// <param name="lifecycle">The life cycle.</param>
    void Register<TService>(object instance, Lifecycle lifecycle);
}
```

The Lifecycle enum consists of the following items:

```csharp
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
```

## An Example on how to do Registration with ContainerAbstraction
You can use the following example code as template poin to start registering
your classes:

```csharp
private class ExampleConfigurator : IContainerConfigurator
{
    public void Configure(IContainerConfiguration configuration)
    {
        configuration.Register<ITypeExample, TypeExampleImpl>();
        configuration.Register<ITypeExample2, TypeExampleImpl2>(Lifecycle.Singleton);
        
        configuration.Register<IInstanceExample>(new InstanceExampleImpl());
        configuration.Register<IInstanceExample>(new InstanceExampleImpl(), Lifecycle.Singleton);
    }
}
```

## How to Read the Configuration
To read the configurastion, which is spread over several assemblies, the 
Configure assembly contains a static ConfigurationReader class. The 
Read() method will go to every assembly in the folder and search for a
class implementing IConfigurator. It will add the registrations made
there to the container configuration. Also simply call:

```csharp
var containerConfiguration = ConfigurationReader.Read();
```

## How to Configure the real DI Container
To configure the real DI container, you can use the appropiate extension 
assembly. Although it is planned to have more extension assemblies in the 
future, at the moment only support for SimpleInjector is implemented. You 
can reference the Extension... assembly and then simply call the Configure()
extension method on the DI container. An example using SimpleInjector is
shown below:

```csharp
var container = new Container();
container.Configure(containerConfiguration);
```

If you need support for another DI container contact me or you simply can
implement the extension assembly yourself. It's not really hard and you 
can see from the code in the repository how it's done!

HAVE FUN  :-)