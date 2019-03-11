using System;
using System.Collections.Generic;
using System.Text;

namespace WriteOnceMobile
{
    /// <summary>
    /// Interface that will be implemented in a platform-specific manner 
    /// for each device.
    /// </summary>
    public interface IDialer
    {
        //  Method that will be implemented on each platform to trigger the dial.
        bool Dial(string number);
    }
}
