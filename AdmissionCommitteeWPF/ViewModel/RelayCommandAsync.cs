﻿using System.Windows.Input;

namespace AdmissionCommitteeWPF.ViewModel;

public class RelayCommandAsync: ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool> _canExecute;

    public RelayCommandAsync(Func<Task> execute, Func<bool> canExecute = null)
    {
        _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        return _canExecute == null || _canExecute();
    }

    public async void Execute(object parameter)
    {
        await _execute();
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }
}