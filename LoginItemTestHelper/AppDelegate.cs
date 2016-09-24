using AppKit;
using Foundation;
using System.Linq;

namespace LoginItemTestHelper
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            if (!NSWorkspace.SharedWorkspace.RunningApplications.Any(a => a.BundleIdentifier == "net.readify.loginitemtest"))
            {
                var path = new NSString(NSBundle.MainBundle.BundlePath)
                    .DeleteLastPathComponent()
                    .DeleteLastPathComponent()
                    .DeleteLastPathComponent()
                    .DeleteLastPathComponent();
                var pathToExecutable = path + @"Contents/MacOS/FindMe.TrayApp";

                if (NSWorkspace.SharedWorkspace.LaunchApplication(pathToExecutable)) { }
                else NSWorkspace.SharedWorkspace.LaunchApplication(path);
            }

            NSApplication.SharedApplication.Terminate(this);

        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }
    }
}
