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
    }
}
