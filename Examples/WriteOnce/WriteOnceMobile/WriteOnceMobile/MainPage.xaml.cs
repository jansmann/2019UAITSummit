using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WriteOnceMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method will take care of the click event for the button on the page.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await DisplayAlert("Alert", "You clicked me", "OK");
        }
    }
}
