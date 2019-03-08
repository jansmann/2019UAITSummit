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

            //  Let's create a basic stack layout to house some UI Controls.
            var layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center, //   Placement on the vertical plane, scaled for the device.
                Children =
                {
                    new Label
                    {
                       HorizontalTextAlignment = TextAlignment.Center,
                       Text = "Welcome to WriteOnce!"
                    }
                }
            };

            //  Override the main page layout and add this new one.
            MainPage = new ContentPage
            {
                Content = layout
            };

            //
            //  Let's create a classy button...
            Button button = new Button
            {
                Text = "Click Me"
            };

            //  ...and wire up an event to handle the click...
            button.Clicked += async (s, e) => {
                await MainPage.DisplayAlert("Alert", "You clicked me", "OK");
            };


            //  ...and add this item to the layout.
            layout.Children.Add(button);

            //
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
