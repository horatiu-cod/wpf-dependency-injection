namespace wpfDependencyInjectionSetup.Helpers.Abstractions
{
    internal interface IServiceFactory<T>
    {
        T Create();
    }
}