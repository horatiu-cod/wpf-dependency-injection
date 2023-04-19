using System;
using wpfDependencyInjectionSetup.Helpers.Stores;

namespace wpfDependencyInjectionSetup.ViewModels;

internal class MainViewModel : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel =>_navigationStore.CurrentViewModel;

    public MainViewModel(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChamged;
    }

    private void OnCurrentViewModelChamged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }
}
