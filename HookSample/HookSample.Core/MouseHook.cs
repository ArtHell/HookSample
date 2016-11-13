using System;

namespace HookSample.Core
{
    public class MouseHook : Hook
    {
        /// <summary>
        /// Initialize a new instance of the KeyboardHook class.
        /// </summary>
        public MouseHook()
            : base(WH_MOUSE_LL)
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
            if (nCode >= 0 && wParam == (IntPtr)WM_LBUTTONDOWN || wParam == (IntPtr)WM_RBUTTONDOWN)
                // Launches the core method.
                CallbackCore((long)wParam);

            // Calls base method.
            return base.HookCallback(nCode, wParam, lParam);
        }

        /// <summary>
        /// Starts core functionality for the specified key.
        /// </summary>
        /// <param name="type">The type.</param>
        protected virtual void CallbackCore(long type)
        {
            var text = "";
            switch (type)
            {
                case WM_LBUTTONDOWN: text = "Left mouse button"; break;
                case WM_RBUTTONDOWN: text = "Right mouse button"; break;
            }

            // Writes the key to log.
            Log.Instance.WriteMouseLog(text);
        }

        #region Constants

        /// <summary>
        /// Defines that a hook procedure monitors low-level mouse input events.
        /// </summary>
        protected const int WH_MOUSE_LL = 14;

        /// <summary>
        /// Defines a left button event.
        /// </summary>
        protected const long WM_LBUTTONDOWN = 0x0201;

        /// <summary>
        /// Defines a right button event.
        /// </summary>
        protected const long WM_RBUTTONDOWN = 0x0204;

        #endregion
    }
}