using Android.Content;
using System.Linq;
using Android.Telephony;
using Xamarin.Forms;

using Uri = Android.Net.Uri;
using WriteOnceMobile.Droid;

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
    	/// <summary>
    	/// Dial the phone, Android Style!
    	/// </summary>
		public bool Dial(string number)
		{
            //  Shift to the correct Android application context (post Xamarin.Forms 2.5)
			var context = Android.App.Application.Context;
			if (context == null)
				return false;

			var intent = new Intent(Intent.ActionCall);
			intent.SetData(Uri.Parse("tel:" + number));

			if (IsIntentAvailable(context, intent)) {
				context.StartActivity(intent);
				return true;
			}

			return false;
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
