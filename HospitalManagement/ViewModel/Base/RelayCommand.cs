using System;
using System.Windows.Input;

namespace HospitalManagement.ViewModel.Base
{
    public class RelayCommand : ICommand
    {
        private Action action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand(Action action) => this.action = action;

        public bool CanExecute(object param) => true;

        public void Execute(object param) => action();
    }
}
