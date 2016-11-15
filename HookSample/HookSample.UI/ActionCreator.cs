//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core;
using HookSample.Core.Actions;

namespace HookSample.UI
{
    /// <summary>
    /// Provides a creator of actions from console text commands.
    /// </summary>
    internal static class ActionCreator
    {
        /// <summary>
        /// Creates a new action from the specified text command.
        /// </summary>
        /// <param name="command">The command to create the action from.</param>
        /// <returns>The new action.</returns>
        public static IHookAction Create(string command, Hook hook)
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

                // Creates a new MenuVisibilityAction.
                case "visibility":
                    action = new MenuVisibilityAction();
                    break;

                case "hide":
                    action = new KeyHideAction(hook);
                    break;

                case "print":
                    action = new KeyPressAction(argument, hook);
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
