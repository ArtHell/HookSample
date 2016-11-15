//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace HookSample.Core
{
    /// <summary>
    /// Provides basic functionality for a hook.
    /// This is an abstract class.
    /// </summary>
    public abstract class Hook : IDisposable
    {
        /// <summary>
        /// The handle of the hook.
        /// </summary>
        protected IntPtr hookId = IntPtr.Zero;
        
        /// <summary>
        /// The pointer to the hook procedure.
        /// </summary>
        protected HookProc proc = null;

        /// <summary>
        /// The delegate for the hook procedure.
        /// </summary>
        protected delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Initializes a new instance of the Hook class with the specified type of the hook.
        /// </summary>
        /// <param name="hookType"></param>
        public Hook(int hookType)
        {
            // Sets the hook procedure.
            proc = HookCallback;

            // Initializes the hook.
            Initialize(hookType);
        }

        /// <summary>
        /// Sets the hook of the specified type.
        /// </summary>
        /// <param name="hookType">The type of the hook procedure.</param>
        protected void Initialize(int hookType)
        {
            // Gets the current process.
            using (var curProcess = Process.GetCurrentProcess())
                // Gets the main module of the current process.
                using (var curModule = curProcess.MainModule)
                    // Sets the hook and writes the handle of its procedure.
                    hookId = SetWindowsHookEx(
                        hookType,
                        proc,
                        GetModuleHandle(curModule.ModuleName),
                        0);
        }

        /// <summary>
        /// The callback procedure of the hook.
        /// </summary>
        /// <param name="nCode">The hook code passed to the current hook procedure.</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure.</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure.</param>
        /// <returns>The meaning of the return value depends on the hook type.</returns>
        protected virtual IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // Calls the next hook.
            return CallNextHookEx(hookId, nCode, wParam, lParam);
        }

        /// <summary>
        /// Performs safe stop of the hook.
        /// </summary>
        public virtual void Dispose()
        {
            // Removes the hook from the system.
            UnhookWindowsHookEx(hookId);
        }

        #region Extern

        /// <summary>
        /// Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">The name of the loaded module (either a .dll or .exe file).</param>
        /// <returns>The handle to the specified module.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Installs an application-defined hook procedure into a hook chain.
        /// </summary>
        /// <param name="idHook">The type of the hook procedure to be installed.</param>
        /// <param name="lpfn">A pointer to the hook procedure.</param>
        /// <param name="hMod">A handle to the DLL containing the hook procedure.</param>
        /// <param name="dwThreadId">The identifier of the thread with which the hook procedure is to be associated.</param>
        /// <returns>The handle to the hook procedure.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern IntPtr SetWindowsHookEx(
            int idHook,
            HookProc lpfn,
            IntPtr hMod,
            uint dwThreadId);

        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain.
        /// </summary>
        /// <param name="hhk">This parameter is ignored.</param>
        /// <param name="nCode">The hook code passed to the current hook procedure.
        /// The next hook procedure uses this code to determine how to process the hook information.</param>
        /// <param name="wParam">The wParam value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <param name="lParam">The lParam value passed to the current hook procedure.
        /// The meaning of this parameter depends on the type of hook associated with the current hook chain.</param>
        /// <returns>The meaning of the return value depends on the hook type.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        protected static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">A handle to the hook to be removed.</param>
        /// <returns>true if the method succeeds; otherwise, false.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        protected static extern bool UnhookWindowsHookEx(IntPtr hhk);

        #endregion
    }
}
