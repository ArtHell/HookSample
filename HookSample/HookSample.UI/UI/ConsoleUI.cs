//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.Runtime.InteropServices;

namespace HookSample.UI
{
    public abstract class ConsoleUI
    {
        #region Extern

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        #endregion

        public static bool IsVisible { get; protected set; } = true;
        private static IntPtr Handle
        {
            get
            {
                return GetConsoleWindow();
            }
        }

        public static void ChangeVisibility()
        {
            if (IsVisible == true)
                Hide();
            else
                Show();
        }
        public static void Hide()
        {
            ShowWindow(Handle, SW_HIDE);
            IsVisible = false;
        }
        public static void Show()
        {
            ShowWindow(Handle, SW_SHOW);
            IsVisible = true;
        }

        protected int GetInput()
        {
            var input = 0;
            int.TryParse(Console.ReadLine(), out input);
            return input;
        }

        protected void Anykey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        protected void PrintMenu(params string[] menuItems)
        {
            var counter = 1;
            foreach (var item in menuItems)
            {
                Console.WriteLine(counter + ". " + item);
                counter++;
            }
        }

        protected virtual void Layout()
        {
            Console.Clear();
        }
    }
}
