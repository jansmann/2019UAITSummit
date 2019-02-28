# Write Once, Run Thrice: Using Xamarin to Share Code with native iOS, Android and Windows Phone Apps
## Abstract for Session
If you have a small development staff but have clients demanding mobile apps for the major platforms, fear not! This demo-heavy, hands-on workshop will give a very brief, Julia Child- esque overview of how you can write shared C# or F# code that will compile into full-featured native apps... apps that are able to access device features such as GPS, Bluetooth and push notifications.


This repository contains the code used during the workshop where a sample mobile app was created to demonstrate the considerations -- and effort involved -- in going from zero to supporting three distinct ecosystems with minimal platform-specific alterations.  Branches have been created for each of the "before" and "after" waypoints that were used in the demo.

## Considerations
In order to review the code, the following system configuration(s) are recommended:
- Windows workstation running Windows 10, or
- MacOS-powered workstation
- Windows Users:
  - Visual Studio Community 2017 (free) with Xamarin Tools installed
  - .Net Standard 2.x SDK
  - Windows Mobile SDK
  - Android SDK
  - Git command line tools
- Mac Users
  - Visual Studio Community 2017 (free) for the Mac
  - Git command line tools
  - XCode
  - Android Studio (recommended but not required)
  
**Note**: If you wish to compile the iOS example application, a Mac is required due to Apple licensing regulations.  Windows users wanting this option will need to ensure the Mac is available on the same subnet and reachable by the PC.  Similarly, if you are solely on a Mac, be aware that the Windows Phone examples cannot be accessed on the Mac.
