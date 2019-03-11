using WriteOnceMobile.WinPhone;
using Xamarin.Forms;


// This same attribute definition needs to go in each platform-specific file.
[assembly: Dependency(typeof(PhoneDialer))]
namespace WriteOnceMobile.WinPhone
{
    /// <summary>
    /// This helper class includes goodies that will perform platform-specific
    /// operations on Windows Mobile.  Interface needs to be defined in the shared class.
    /// </summary>
    public class PhoneDialer : IDialer
    {
        /// <summary>
        /// Dial, Windows UWP style!
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool Dial(string number)
        {
            //  Windows must reference the Windows Mobile Extensions for UWP in order to make the call.
            //  Once the correct SDK is referenced, this is the correct line for UWP apps to trigger the dialing.
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(number, "Call");
                			
            return true;
        }
    }
}