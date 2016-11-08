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
            using (var hook = new ExtendedKeyboardHook())
            {
                var task = new Task(() =>
                {
                    var ui = new KeyboardHookConsoleUI(hook);
                    ui.MainMenu();
                });
                task.Start();

                Application.Run();
            }
        }
    }
}
