using Android.Content;
using System.Linq;
using Android.Telephony;
using Xamarin.Forms;

using Uri = Android.Net.Uri;
using WriteOnceMobile.Droid;
using Android;

// This same attribute definition needs to go in each platform-specific file.
[assembly: Dependency(typeof(PhoneDialer))]
namespace WriteOnceMobile.Droid
{

    /// <summary>
    /// This helper class includes goodies that will perform platform-specific
    /// operations on Android.  Interface needs to be defined in the shared class.
    /// </summary>
    public class PhoneDialer : IDialer
    {
        //  String for testing what permissions have been set.
        private const string CallPhonePermission = Manifest.Permission.CallPhone;

        /// <summary>
        /// Dial the phone, Android Style!
        /// </summary>
        public bool Dial(string number)
		{
            //  Shift to the correct Android application context (post Xamarin.Forms 2.5)
			var context = Android.App.Application.Context;
			if (context == null)
				return false;
                
            //  As of API 23, must additionally check to see if permission has been granted.
            if (context.CheckSelfPermission(CallPhonePermission) == Android.Content.PM.Permission.Granted)
            {

                var intent = new Intent(Intent.ActionCall);
                intent.SetData(Uri.Parse("tel:" + number));

                if (IsIntentAvailable(context, intent))
                {
                    context.StartActivity(intent);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                //  Permission has not been granted, though the manifest should have requested it.  However, our simulators
                //  don't always respond correctly to the manifest settings.  
                //  In any case, we typically we would want to force a security prompt if this gets dropped to here, 
                //  but for this example, will instead manually grant the app access on the simulator.
                return false;
            }
		}

        /// <summary>
        /// Checks if an intent can be handled.  If not, the call will
        /// return false and prevent the operation from taking place.
        /// </summary>
		public static bool IsIntentAvailable(Context context, Intent intent)
        {
            var packageManager = context.PackageManager;
            
			var list = packageManager.QueryIntentServices(intent, 0)
				.Union(packageManager.QueryIntentActivities(intent, 0));
			if (list.Any())
				return true;
            
			TelephonyManager mgr = TelephonyManager.FromContext(context);
			return mgr.PhoneType != PhoneType.None;
        }
    }
}
