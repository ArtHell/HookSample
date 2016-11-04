//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;

namespace HookSample.Core
{
    public class KeyPressedEventArgs : EventArgs
    {
        public KeyPressedEventArgs(int key)
        {
            Key = key;
        }

        public int Key { get; private set; }
    }

    public class ExtendedKeyboardHook : KeyboardHook
    {
    }
}
