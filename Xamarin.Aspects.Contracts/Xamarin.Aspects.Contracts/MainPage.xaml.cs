using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace Xamarin.Aspects.Contracts
{

    public partial class MainPage : ContentPage
	{
	    public TestCommand TestCommand => new TestCommand();
        public MainPage()
		{
			InitializeComponent();
		    this.BindingContext = this;
		   
        }

        private void TestCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            var x = sender;
            Console.WriteLine("fired");
        }
    }
}
