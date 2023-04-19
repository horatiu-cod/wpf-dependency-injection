using wpfDependencyInjectionSetup.Helpers.Abstractions;

namespace wpfDependencyInjectionSetup.Helpers.Commands;

internal class NavigationCommand : CommandBase
{
    private readonly INavigationService _navigationService;

    public NavigationCommand(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }

    public override void Execute(object? parameter)
    {
        _navigationService.Navigate();
    }
}
