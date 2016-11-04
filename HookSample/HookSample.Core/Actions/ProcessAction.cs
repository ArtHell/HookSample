//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

namespace HookSample.Core.Actions
{
    /// <summary>
    /// Represents a hook action that works with a process.
    /// </summary>
    public abstract class ProcessAction : IHookAction
    {
        /// <summary>
        /// The process name.
        /// </summary>
        protected string processName = null;

        /// <summary>
        /// Initializes a new instance of the ProcessAction class with the specified process name.
        /// </summary>
        /// <param name="processName">The name of the process to work with.</param>
        public ProcessAction(string processName)
        {
            // Sets the process name.
            this.processName = processName;
        }

        /// <summary>
        /// Executes the action.
        /// </summary>
        public virtual void Execute()
        {
            // Checks if the process name is empty and terminates the method if yes.
            if (string.IsNullOrEmpty(processName))
                return;
        }

        /// <summary>
        /// Returns a string that represents the ProcessAction.
        /// </summary>
        /// <returns>A string that represents the ProcessAction.</returns>
        public override string ToString()
        {
            return " " + processName;
        }
    }
}
