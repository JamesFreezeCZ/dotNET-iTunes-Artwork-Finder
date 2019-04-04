﻿using System;
using System.Windows.Input;

namespace iTunesArtworkFinder.MVVM
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(p => execute(), p => canExecute?.Invoke() ?? true)
        {
        }

        public bool CanExecute(object parameter)
        {
            return this._canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            this._execute?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

    }
}