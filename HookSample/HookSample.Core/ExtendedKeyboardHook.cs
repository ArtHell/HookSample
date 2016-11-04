//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;

namespace HookSample.Core
{
    /// <summary>
    /// Contains event data for key pressed events.
    /// </summary>
    public class KeyPressedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the KeyPressedEventArgs class.
        /// </summary>
        /// <param name="key">A key that has been pressed.</param>
        public KeyPressedEventArgs(int key)
        {
            // Sets the key.
            Key = key;
        }

        /// <summary>
        /// Gets the key that has been pressed.
        /// </summary>
        public int Key { get; private set; }
    }

    /// <summary>
    /// Represents an extended keyboard hook that provides events of a key pressing
    /// and actions sequences that are binded to keys.
    /// </summary>
    public class ExtendedKeyboardHook : KeyboardHook
    {
        /// <summary>
        /// The delegate for the KeyPressed event.
        /// </summary>
        public delegate void KeyPressedHandler(object sender, KeyPressedEventArgs e);
        /// <summary>
        /// Occurs when a key pressed during the working hook.
        /// </summary>
        public event KeyPressedHandler KeyPressed;

        /// <summary>
        /// Starts core functionality for the specified key.
        /// </summary>
        /// <param name="vkCode">The virtual code of the key.</param>
        protected override void CallbackCore(int vkCode)
        {
            // Calls base method.
            base.CallbackCore(vkCode);

            // Invokes handler of the event.
            KeyPressed?.Invoke(this, new KeyPressedEventArgs(vkCode));
        }
    }
}
