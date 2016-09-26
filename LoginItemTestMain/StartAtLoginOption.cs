using System;
using System.Runtime.InteropServices;
using Foundation;
namespace LoginItemTestMain
{
    public class StartAtLoginOption
    {
        [DllImport("/System/Library/Frameworks/ServiceManagement.framework/ServiceManagement")]
        static extern bool SMLoginItemSetEnabled(IntPtr aId, bool aEnabled);

        public static bool StartAtLogin(bool value)
        {
            CoreFoundation.CFString id = new CoreFoundation.CFString("net.readify.loginitemtesthelper");
            return SMLoginItemSetEnabled(id.Handle, value);
        }
    }
}
