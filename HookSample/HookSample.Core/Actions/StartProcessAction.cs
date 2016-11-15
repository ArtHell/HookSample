//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookSample.Core.Actions
{
    /// <summary>
    /// Represents a hook action that starts a process.
    /// </summary>
    public class StartProcessAction : ProcessAction
    {
        /// <summary>
        /// The background option.
        /// </summary>
        protected bool startInBackground = false;

        /// <summary>
        /// Initializes a new instance of the StartProcessAction class with the specified process name.
        /// </summary>
        /// <param name="processName">The name of the process to start.</param>
        public StartProcessAction(string processName)
            : this(processName, false)
        { }
        /// <summary>
        /// Initializes a new instance of the StartProcessAction class with the specified process name and background option.
        /// </summary>
        /// <param name="processName">The name of the process to start.</param>
        /// <param name="startInBackground">Determines whether the process window starts in background.</param>
        public StartProcessAction(string processName, bool startInBackground)
            : base(processName)
        {
            // Sets the background option.
            this.startInBackground = startInBackground;
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        public override void Execute()
        {
            // Calls base method.
            base.Execute();

            try
            {
                // Creates the process start info instance using the process name.
                var info = new ProcessStartInfo(processName);
                // Sets the background option.
                if (startInBackground == true)
                    info.WindowStyle = ProcessWindowStyle.Hidden;

                // Starts the process.
                var process = Process.Start(info);
            }
            catch (Exception ex)
            {
                // Writes the error in the log.
                Log.Instance.WriteAppLog("Process start error: " + processName + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a string that represents the StartProcessAction.
        /// </summary>
        /// <returns>A string that represents the StartProcessAction.</returns>
        public override string ToString()
        {
            return "start" + base.ToString();
        }
    }

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

    public class KeyHideAction : IHookAction
    {
        private Hook hook;

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public KeyHideAction(Hook hook)
        {
            this.hook = hook;
        }


        /// <summary>
        /// Returns a string that represents the StartProcessAction.
        /// </summary>
        /// <returns>A string that represents the StartProcessAction.</returns>
        public override string ToString()
        {

            return "hide";
        }

        public void Execute()
        {
        }
    }
}
