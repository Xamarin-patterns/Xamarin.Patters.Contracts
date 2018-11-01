using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Aspects.Contracts.Commands.Network;
using Xamarin.Aspects.Contracts.Framework;
using Xamarin.Forms;

namespace Xamarin.Aspects.Contracts
{
    [CommandContract(typeof(InternetContract))]
    [CommandContract(typeof(InternetContract))]

    public class ConstrainedCommand: ICommand
    {
        private readonly Command _command;
      
        public ConstrainedCommand(Action<object> execute) 
        {
            _command=new Command(execute);
        }

        public ConstrainedCommand(Action execute) 
        {
            _command = new Command(execute);

        }

        public ConstrainedCommand(Action<object> execute, Func<object, bool> canExecute) 
        {
            _command = new Command(execute,canExecute);

        }

        public ConstrainedCommand(Action execute, Func<bool> canExecute) 
        {
            _command = new Command(execute, canExecute);

        }
        public virtual bool CanExecute(object parameter)
        {
            return _command.CanExecute(parameter);
        }

        public virtual void Execute(object parameter)
        {
            _command.Execute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}
