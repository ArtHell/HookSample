//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core.Actions;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookSample.Core
{
    /// <summary>
    /// Represents a keyboard hook.
    /// </summary>
    public class KeyboardHook : Hook
    {
        /// <summary>
        /// Gets the dictionary with keys and corresponding action sequences.
        /// </summary>
        public IDictionary<char, ActionSequence> Sequences { get; } = new Dictionary<char, ActionSequence>();

        /// <summary>
        /// Initialize a new instance of the KeyboardHook class.
        /// </summary>
        public KeyboardHook()
            : base(WH_KEYBOARD_LL)
        { }

        /// <summary>
        /// The callback procedure of the hook.
        /// </summary>
        /// <param name="nCode">The hook code passed to the current hook procedure.</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure.</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure.</param>
        protected override IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
                        // Checks if the hook is correct and a keypressed event is happened.
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
                // Launches the core method.
                CallbackCore(Marshal.ReadInt32(lParam));


            if (HideKey(Marshal.ReadInt32(lParam)))
            {
                return (IntPtr)1;
            }
            // Calls base method.
            return base.HookCallback(nCode, wParam, lParam);
        }

        private bool HideKey(int key)
        {
            if (Sequences.ContainsKey((char)key))
            {
                // Gets the sequence.
                var sequence = Sequences[(char)key];
                // Checks if the sequence is not null.
                if (sequence != null)
                {
                    return sequence.Exists(x => x.ToString() == "hide");
                }
            }
            return false;
        }

        /// <summary>
        /// Starts core functionality for the specified key.
        /// </summary>
        /// <param name="vkCode">The virtual code of the key.</param>
        protected virtual void CallbackCore(int vkCode)
        {

            
        // Converts the code to a string value (firstly getting the key assigned to it).
        var text = ((Keys)vkCode).ToString();

            // Writes the key to log.
            Log.Instance.WriteKeyboardLog(text);
        }

        #region Constants

        /// <summary>
        /// Defines that a hook procedure monitors low-level keyboard input events.
        /// </summary>
        protected const int WH_KEYBOARD_LL = 13;
        /// <summary>
        /// Defines a key down keyboard event.
        /// </summary>
        protected const int WM_KEYDOWN = 0x0100;

        #endregion
    }
}
