using System;
using wpfDependencyInjectionSetup.Helpers.Abstractions;

namespace wpfDependencyInjectionSetup.Helpers.Factories;

internal class ServiceFactory<T> : IServiceFactory<T>
{
    private readonly Func<T> _factory;

    public ServiceFactory(Func<T> factory)
    {
        _factory = factory;
    }

    public T Create()
    {
        return _factory();
    }
}
