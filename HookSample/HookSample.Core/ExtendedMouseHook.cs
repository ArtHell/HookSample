using System.Collections.Generic;
using HookSample.Core.Actions;

namespace HookSample.Core
{
    public class ExtendedMouseHook : MouseHook
    {
        /// <summary>
        /// Gets the dictionary with keys and corresponding action sequences.
        /// </summary>
        public IDictionary<char, ActionSequence> Sequences { get; } = new Dictionary<char, ActionSequence>();

        /// <summary>
        /// Starts core functionality for the specified key.
        /// </summary>
        /// <param name="type">The virtual code of the key.</param>
        protected override void CallbackCore(long type)
        {
            // Calls base method.
            base.CallbackCore(type);

            // Manages actions.
            ManageActions(type);
        }

        /// <summary>
        /// Executes actions for the specified key if the actions are set.
        /// </summary>
        /// <param name="key">The key to get an action sequence for.</param>
        private void ManageActions(long key)
        {
            if (Sequences.ContainsKey((char)253) && key == WM_LBUTTONDOWN)
            {
                // Gets the sequence.
                var sequence = Sequences[(char)253];
                // Checks if the sequence is not null.
                if (sequence != null)
                    // Starts the every action in the sequence.
                    foreach (var action in sequence)
                        action.Execute();
            }

            if (Sequences.ContainsKey((char)251) && key == WM_RBUTTONDOWN)
            {
                // Gets the sequence.
                var sequence = Sequences[(char)251];
                // Checks if the sequence is not null.
                if (sequence != null)
                    // Starts the every action in the sequence.
                    foreach (var action in sequence)
                        action.Execute();
            }
        }
    }
}