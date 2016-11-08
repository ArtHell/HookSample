//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core.Actions;

namespace HookSample.UI
{
    /// <summary>
    /// Provides a creator of actions from text commands.
    /// </summary>
    public static class ActionCreator
    {
        /// <summary>
        /// Creates a new action from the specified text command.
        /// </summary>
        /// <param name="command">The command to create the action from.</param>
        /// <returns>The new action.</returns>
        public static IHookAction Create(string command)
        {
            // Creates an empty action.
            IHookAction action = null;

            // Splits the command text.
            var substrings = command.Split(' ');
            // Sets the function text.
            var function = substrings[0];
            // Sets the argument text if it exists.
            var argument = substrings.Length > 1 ? substrings[1] : "";

            // Switches the function text.
            switch (function)
            {
                // Creates a new StartProcessAction.
                case "start":
                    action = new StartProcessAction(argument);
                    break;

                // Creates a new KillProcessAction.
                case "kill":
                    action = new KillProcessAction(argument);
                    break;

                // Creates nothing.
                case "default":
                    break;
            }

            // Returns the action.
            return action;
        }
    }
}
