//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core.Actions;
using System;
using System.Collections.Generic;

namespace HookSample.Core
{
    /// <summary>
    /// Represents an extended keyboard hook that provides actions sequences binded to keys.
    /// </summary>
    public class ExtendedKeyboardHook : KeyboardHook
    {
        /// <summary>
        /// Gets the dictionary with keys and corresponding action sequences.
        /// </summary>
        public IDictionary<int, ActionSequence> Sequences { get; } = new Dictionary<int, ActionSequence>();

        /// <summary>
        /// Starts core functionality for the specified key.
        /// </summary>
        /// <param name="vkCode">The virtual code of the key.</param>
        protected override void CallbackCore(int vkCode)
        {
            // Calls base method.
            base.CallbackCore(vkCode);

            // Manages actions.
            ManageActions(vkCode);
        }

        /// <summary>
        /// Executes actions for the specified key if the actions are set.
        /// </summary>
        /// <param name="key">The key to get an action sequence for.</param>
        private void ManageActions(int key)
        {
            // Checks if the dictionary contains the such key.
            if (Sequences.ContainsKey(key))
            {
                // Gets the sequence.
                var sequence = Sequences[key];
                // Checks if the sequence is not null.
                if (sequence != null)
                    // Starts the every action in the sequence.
                    foreach (var action in sequence)
                        action.Execute();
            }
        }
    }

    public class ExtendedMouseHook : MouseHook
    {
        /// <summary>
        /// Gets the dictionary with keys and corresponding action sequences.
        /// </summary>
        public IDictionary<int, ActionSequence> Sequences { get; } = new Dictionary<int, ActionSequence>();

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
            if (Sequences.ContainsKey(253) && key == WM_LBUTTONDOWN)
            {
                // Gets the sequence.
                var sequence = Sequences[253];
                // Checks if the sequence is not null.
                if (sequence != null)
                    // Starts the every action in the sequence.
                    foreach (var action in sequence)
                        action.Execute();
            }

            if (Sequences.ContainsKey(251) && key == WM_RBUTTONDOWN)
            {
                // Gets the sequence.
                var sequence = Sequences[251];
                // Checks if the sequence is not null.
                if (sequence != null)
                    // Starts the every action in the sequence.
                    foreach (var action in sequence)
                        action.Execute();
            }
        }
    }
}
