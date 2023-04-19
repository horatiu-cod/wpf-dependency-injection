using System;
using System.Threading.Tasks;

namespace wpfDependencyInjectionSetup.Helpers.Commands;

internal abstract class AsyncCommandBase : CommandBase
{
	private bool _IsExecuting;

	public bool IsExecuting
	{
		get { return _IsExecuting; }
		set { _IsExecuting = value; OnCanExecuteChanged(); }
	}

    public override bool CanExecute(object? parameter)
    {
        return IsExecuting &&  base.CanExecute(parameter);
    }
    public override async void Execute(object? parameter)
    {
        IsExecuting = true;
        await ExecuteAsync(parameter);
        IsExecuting = false;
    }

    public abstract Task ExecuteAsync(object? parameter);
}
