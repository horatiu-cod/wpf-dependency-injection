using Microsoft.Extensions.DependencyInjection;
using System;
using wpfDependencyInjectionSetup.Helpers.Abstractions;
using wpfDependencyInjectionSetup.Helpers.Factories;
using wpfDependencyInjectionSetup.Helpers.Services;
using wpfDependencyInjectionSetup.ViewModels;

namespace wpfDependencyInjectionSetup.Helpers.Extensions;

internal static class ServiceExtension
{
    internal static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        //Regidter services for TForms
        services.AddFormFactory<ViewModelBase>();
        services.AddSingleton<INavigationService, NavigationService>();
    }
    // Factory Pattern
    internal static void AddFormFactory<TForm>(this IServiceCollection services)
        where TForm : class
    {
        services.AddTransient<TForm>();
        services.AddSingleton<Func<TForm>>(x => () => x.GetService<TForm>()!);
        services.AddSingleton<IServiceFactory<TForm>, ServiceFactory<TForm>>();
    }
}
