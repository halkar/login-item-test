// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace LoginItemTestMain
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSButton SwitchLaunchAtStartup { get; set; }

		[Action ("OnLaunchAtStartupChanged:")]
		partial void OnLaunchAtStartupChanged (AppKit.NSButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (SwitchLaunchAtStartup != null) {
				SwitchLaunchAtStartup.Dispose ();
				SwitchLaunchAtStartup = null;
			}
		}
	}
}
