//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System.Collections.Generic;
using System.Text;

namespace HookSample.Core.Actions
{
    /// <summary>
    /// Provides a collection of actions.
    /// </summary>
    public class ActionSequence : List<IHookAction>
    {
        /// <summary>
        /// Returns a string that represents the ActionSequence.
        /// </summary>
        /// <returns>A string that represents the ActionSequence.</returns>
        public override string ToString()
        {
            // Creates a new string builder and appends every action string to it.
            var builder = new StringBuilder();
            foreach (var action in this)
                builder.AppendLine("   " + action.ToString());

            // Returns the builder value.
            return builder.ToString();
        }
    }
}
