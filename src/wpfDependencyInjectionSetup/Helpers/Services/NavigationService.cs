using wpfDependencyInjectionSetup.Helpers.Abstractions;
using wpfDependencyInjectionSetup.Helpers.Stores;
using wpfDependencyInjectionSetup.ViewModels;

namespace wpfDependencyInjectionSetup.Helpers.Services;

internal class NavigationService : INavigationService
{
    private readonly NavigationStore _navigationStore;
    private readonly IServiceFactory<ViewModelBase> _viewModelFactory;

    public NavigationService(NavigationStore navigationStore, IServiceFactory<ViewModelBase> viewModelFactory)
    {
        _navigationStore = navigationStore;
        _viewModelFactory = viewModelFactory;
    }

    public void Navigate()
    {
        _navigationStore.CurrentViewModel = _viewModelFactory.Create();
    }
}
