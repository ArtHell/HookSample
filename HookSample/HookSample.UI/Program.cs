//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookSample.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var keyboardHook = new ExtendedKeyboardHook())
            {
                // Creates an instance of the hook (with using statement because it's IDisposable).
                using (var mouseHook = new ExtendedMouseHook())
                {
                    // Creates a task for parallel console UI work.
                    var task = new Task(() =>
                    {
                        // Creates an instance of the UI.
                        var ui = new KeyboardHookConsoleUI(keyboardHook, mouseHook);
                        // Starts the UI.
                        ui.MainMenu();
                    });
                    // Starts the task.
                    task.Start();

                    // Runs a message loop on the current thread.
                    Application.Run();
                }
            }
        }
    }
}
