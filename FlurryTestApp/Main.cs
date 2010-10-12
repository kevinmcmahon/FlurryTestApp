using System;
using System.Collections.Generic;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using FlurryWithLocation;

namespace FlurryTestApp
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
		public const string FlurryApiKey = "INSERT_YOUR_DEBUG_KEY_HERE";  // Debug
		//public const string FlurryApiKey = "INSERT_YOUR_RELEASE_KEY_HERE"; // Release
		public const string APP_VERSION = "1.0";
		
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			FlurryAPI.SetAppVersion(APP_VERSION);
			FlurryAPI.StartSession(FlurryApiKey);
			FlurryAPI.SetEventLoggingEnabled(true);
			
			// HACK to make sure some libraries that Flurry has weak dependencies on don't get optimized
			// away.
			window.Frame.GetMidX();
			
			button.TouchDown += delegate {
				FlurryAPI.LogEvent("TestAppButtonClicked");
				Console.WriteLine("Button Clicked");
			};
			
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);
			
			window.MakeKeyAndVisible ();
			
			return true;
		}

		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
	}
}