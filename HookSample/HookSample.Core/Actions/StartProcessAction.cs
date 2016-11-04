//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.Diagnostics;

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
                Log.Instance.Write("Process start error: " + processName + " - " + ex.Message);
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
}
