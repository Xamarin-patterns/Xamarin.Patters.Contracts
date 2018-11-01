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
	    public ConstrainedCommand TestCommand => new ConstrainedCommand(() => {});
        public MainPage()
		{
			InitializeComponent();
		    this.BindingContext = this;
		   
        }

     
    }
}
