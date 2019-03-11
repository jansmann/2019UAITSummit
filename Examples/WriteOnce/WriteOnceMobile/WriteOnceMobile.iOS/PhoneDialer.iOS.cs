using Foundation;
using UIKit;
using WriteOnceMobile.iOS;
using Xamarin.Forms;

// This same attribute definition needs to go in each platform-specific file.
[assembly: Dependency(typeof(PhoneDialer))]
namespace WriteOnceMobile.iOS
{
    /// <summary>
    /// This helper class includes goodies that will perform platform-specific
    /// operations on iOS.  Interface needs to be defined in the shared class.
    /// </summary>
    public class PhoneDialer : IDialer
    {
        /// <summary>
        /// Dial the phone, iOS Style!
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Dial(string number)
        {
            //  Simplier call than Android; iOS treats it as a URL type of call.
            return UIApplication.SharedApplication.OpenUrl(new NSUrl("tel:" + number));
        }
    }
}
