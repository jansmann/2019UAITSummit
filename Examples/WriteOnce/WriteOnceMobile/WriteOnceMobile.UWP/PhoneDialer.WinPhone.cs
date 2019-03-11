using Microsoft.Phone.Tasks;

namespace WriteOnceMobile.WinPhone
{
    /// <summary>
    /// This helper class includes goodies that will perform platform-specific
    /// operations on Windows Mobile.  Interface needs to be defined in the shared class.
    /// </summary>
    public class PhoneDialer : IDialer
    {
        public bool Dial(string number)
        {
            PhoneCallTask phoneCallTask = new PhoneCallTask 
			{ 
				PhoneNumber = number, DisplayName = "Phoneword" 
			};
            
			phoneCallTask.Show();
            return true;
        }
    }
}