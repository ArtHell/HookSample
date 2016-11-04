//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

namespace HookSample.Core.Actions
{
    /// <summary>
    /// Defines an action called by a hook after a specified key event.
    /// </summary>
    public interface IHookAction
    {
        /// <summary>
        /// Executes the action.
        /// </summary>
        void Execute();
    }
}
