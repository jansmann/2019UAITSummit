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
        /// <summary>
        /// Some global properties that we will use.
        /// </summary>

        
        //  Placeholder for the translation
        public string TranslatedNumber { get; set; }

        //  Padding for devices
        public double PaddingAmount { get; set; }


        public MainPage()
        {
            InitializeComponent();

            //  Minor UI Tweak - this will ensure that we have appropriate padding around the
            //  UI across all devices.
            PaddingAmount = 0.0;
            switch(Device.RuntimePlatform)
            {
                case Device.iOS:
                    PaddingAmount = 40;
                    break;
                default:
                    PaddingAmount = 20;
                    break;
            }

            //  Set it.
            this.Padding = PaddingAmount;
            
        }

        /// <summary>
        /// Examines the text that was entered and attempts to translate it to a
        /// usable phone number.  If it can be used, enable the calling button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TranslateButton_Clicked(object sender, EventArgs e)
        {
            //  Use our helper function to translate the text to a number
            TranslatedNumber = Core.PhonewordTranslator.ToNumber(textToNumber.Text);

            //  A little bit of error handling...
            if (!string.IsNullOrEmpty(TranslatedNumber))
            {
                callButton.IsEnabled = true;
                callButton.Text = "Call " + TranslatedNumber;
            }
            else
            {
                callButton.IsEnabled = false;
                callButton.Text = "Call";
            }
        }

        /// <summary>
        /// Event handler that will trigger the correct "call" function for the
        /// platform that the user is using (Droid, iOS, Windows).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            //  TODO: 05 - Add implementation code here.  May need some platform specific help (hint, hint)
            //  First, let's try to trigger a dialog message.  If they respond correctly, dial.
            if (await DisplayAlert("Dial A Number", $"Would you like to call {TranslatedNumber}?","Yes","No"))
            {
                //  TODO: Dial!  (This will be the platform-specific implementation call)
                //  To aid in this process, we are going to use Dependency injection to implement the interface that is
                //  specific to the platform that is running this code.
                //  DI will located the correct interface for us magically, but only if the classes have been tagged
                //  correctly.
                var dialer = DependencyService.Get<IDialer>();
                if (dialer != null)
                {
                    dialer.Dial(TranslatedNumber);
                }
            }

            
        }


    }
}
