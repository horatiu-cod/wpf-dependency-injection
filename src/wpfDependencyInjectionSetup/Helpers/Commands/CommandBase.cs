using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace wpfDependencyInjectionSetup.Helpers.Commands;

internal abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged;

    // Derived classe con override the CanExecute method
    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }
    //Derived classe has to implement the method
    public abstract void Execute(object? parameter);

    protected void OnCanExecuteChanged() 
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}
