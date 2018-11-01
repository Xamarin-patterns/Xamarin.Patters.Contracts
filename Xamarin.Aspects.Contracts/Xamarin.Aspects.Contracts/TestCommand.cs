using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Aspects.Contracts.Commands.Network;
using Xamarin.Aspects.Contracts.Framework;

namespace Xamarin.Aspects.Contracts
{
    [CommandContract(typeof(InternetContract))]
    public class TestCommand:ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            Forms.Device.BeginInvokeOnMainThread(() =>
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty); 

            });

        }
    }
}
