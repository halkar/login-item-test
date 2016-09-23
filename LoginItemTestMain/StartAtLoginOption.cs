using System;
using System.Runtime.InteropServices;
using Foundation;
namespace LoginItemTestMain
{
    public class StartAtLoginOption
    {
        [DllImport("/System/Library/Frameworks/ServiceManagement.framework/ServiceManagement")]
        static extern bool SMLoginItemSetEnabled(IntPtr aId, bool aEnabled);

        [DllImport("/System/Library/Frameworks/ServiceManagement.framework/ServiceManagement")]
        static extern IntPtr SMJobCopyDictionary(IntPtr aDomain, IntPtr aId);


        #region IStartAtLoginOption implementation
        public static bool StartAtLogin
        {
            get
            {
                CoreFoundation.CFString dom = new CoreFoundation.CFString("kSMDomainUserLaunchd");
                CoreFoundation.CFString id = new CoreFoundation.CFString("net.readify.login-item-test-helper");
                IntPtr dict = SMJobCopyDictionary(dom.Handle, id.Handle);
                return (dict != IntPtr.Zero);
            }
            set
            {
                var nSUrl = NSBundle.MainBundle.BundleUrl.Append("Contents/Library/LoginItems/LoginItemTestHelper.app", false);
                CoreServices.LaunchServices.Register(nSUrl, false);

                CoreFoundation.CFString id = new CoreFoundation.CFString("net.readify.login-item-test-helper");
                bool result = SMLoginItemSetEnabled(id.Handle, value);
            }
        }
        #endregion
    }
}
