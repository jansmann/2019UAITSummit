using Foundation;
using UIKit;


namespace WriteOnceMobile.iOS
{
    /// <summary>
    /// This helper class includes goodies that will perform platform-specific
    /// operations on iOS.  Interface needs to be defined in the shared class.
    /// </summary>
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            return UIApplication.SharedApplication.OpenUrl(
				new NSUrl("tel:" + number));
        }
    }
}
