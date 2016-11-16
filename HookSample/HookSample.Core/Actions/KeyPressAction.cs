using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookSample.Core.Actions
{
    public class KeyPressAction : IHookAction
    {
        private Hook hook;
        private string key;

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public KeyPressAction(string key, Hook hook)
        {
            this.key = key;
            this.hook = hook;
        }


        /// <summary>
        /// Returns a string that represents the StartProcessAction.
        /// </summary>
        /// <returns>A string that represents the StartProcessAction.</returns>
        public override string ToString()
        {

            return "print " + key;
        }

        public void Execute()
        {
            foreach (var k in key)
            {
                KeyDown((Keys)k);
                KeyUp((Keys)k);
            }

        }

        public static void KeyDown(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }

        public static void KeyUp(Keys vKey)
        {
            keybd_event((byte)vKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
    }
}
