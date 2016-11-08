//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core.Actions;

namespace HookSample.UI
{
    /// <summary>
    /// Represents a hook action that changes menu visibility.
    /// </summary>
    public class MenuVisibilityAction : IHookAction
    {
        /// <summary>
        /// Executes the action.
        /// </summary>
        public void Execute()
        {
            // Changes the visibility.
            ConsoleUI.ChangeVisibility();
        }

        /// <summary>
        /// Returns a string that represents the MenuVisibilityAction.
        /// </summary>
        /// <returns>A string that represents the MenuVisibilityAction.</returns>
        public override string ToString()
        {
            return "visibility";
        }
    }
}
