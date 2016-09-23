using System;

using AppKit;
using Foundation;

namespace LoginItemTestMain
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SwitchLaunchAtStartup.State = StartAtLoginOption.StartAtLogin ? NSCellStateValue.On : NSCellStateValue.Off;

            // Do any additional setup after loading the view.
        }

        partial void OnLaunchAtStartupChanged(NSButton sender)
        {
            StartAtLoginOption.StartAtLogin = SwitchLaunchAtStartup.State == NSCellStateValue.On;
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
