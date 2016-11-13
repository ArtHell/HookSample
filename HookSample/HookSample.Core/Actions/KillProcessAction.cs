//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.Diagnostics;

namespace HookSample.Core.Actions
{
    /// <summary>
    /// Represents a hook action that kills a process.
    /// </summary>
    public class KillProcessAction : ProcessAction
    {
        /// <summary>
        /// Initializes a new instance of the KillProcessAction class with the specified process name.
        /// </summary>
        /// <param name="processName">The name of the process to kill.</param>
        public KillProcessAction(string processName)
            : base(processName)
        { }

        /// <summary>
        /// Executes the action.
        /// </summary>
        public override void Execute()
        {
            // Calls base method.
            base.Execute();

            try
            {
                // Gets the list with processes by the process name.
                var processes = Process.GetProcessesByName(processName);

                // Checks if the list is empty and writes to log the corresponding error message.
                if (processes.Length == 0)
                    Log.Instance.WriteAppLog("Process kill error: no processes found for " + processName);
                // Otherwise, kills the every process in the list.
                else
                    Array.ForEach(processes, p => p.Kill());
            }
            catch (Exception ex)
            {
                // Writes the error in the log.
                Log.Instance.WriteAppLog("Process kill error: " + processName + " - " + ex.Message);
            }
        }

        /// <summary>
        /// Returns a string that represents the KillProcessAction.
        /// </summary>
        /// <returns>A string that represents the KillProcessAction.</returns>
        public override string ToString()
        {
            return "kill" + base.ToString();
        }
    }
}
