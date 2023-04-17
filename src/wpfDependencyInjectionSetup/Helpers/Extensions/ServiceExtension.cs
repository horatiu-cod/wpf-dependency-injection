using Microsoft.Extensions.DependencyInjection;
using System;
using wpfDependencyInjectionSetup.Helpers.Abstractions;
using wpfDependencyInjectionSetup.Helpers.Factories;

namespace wpfDependencyInjectionSetup.Helpers.Extensions;

internal static class ServiceExtension
{
    internal static void AddFormFactory<TForm>(this IServiceCollection services)
        where TForm : class
    {
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
        services.AddSingleton<IServiceFactory<TForm>, ServiceFactory<TForm>>();
    }
}
