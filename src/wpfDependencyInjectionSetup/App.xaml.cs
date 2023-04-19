using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using wpfDependencyInjectionSetup.Helpers.Extensions;

namespace wpfDependencyInjectionSetup;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    
    public App()
    {
        // Build the app
        AppHost = Host.CreateDefaultBuilder()
            // Configure dependency injection services
            .ConfigureServices((hostContext, services) =>
            {
                // Register services
                services.AddServices();
                //services.AddSingleton<MainWindow>();
            })
            .Build(); 
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        // Override the Startup method
        await AppHost!.StartAsync();
        // Get Service for MainWindow
        var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
        startupForm.Show();

        base.OnStartup(e);
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();

        base.OnExit(e);
    }
}
