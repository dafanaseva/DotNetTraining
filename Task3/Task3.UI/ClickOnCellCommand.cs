﻿using System;
using System.Windows.Input;

namespace Task3.UI;

internal sealed class ClickOnCellCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool> _canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public ClickOnCellCommand(Action execute, Func<bool> canExecute)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute();
    }

    public void Execute(object? parameter)
    {
        _execute();
    }
}