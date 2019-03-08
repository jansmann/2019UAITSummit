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
        /// To be enabled later.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CallButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
