using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WriteOnceMobile
{
    public partial class App : Application
    {
        /// <summary>
        /// This is the root page of our application.  When the program launches, items in this section will 
        /// be run across all three platforms.
        /// </summary>
        /// <remarks>
        /// Some third party components will require you to add material in this method in order to correctly
        /// wire them up for use.
        /// </remarks>
        public App()
        {
            //  Base call.
            InitializeComponent();

            //  Load and launch the main page of this application.  We've conveniently
            //  called it "MainPage" but you can specify object of type ContentPage.
            //  If necessary, this call may be overridden and a code-derived view could be passed in.                    
            MainPage = new MainPage();


        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
