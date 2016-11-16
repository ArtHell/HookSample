//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using HookSample.Core;
using HookSample.Core.Actions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HookSample.UI
{
    // The code of this class is DRAFT.

    internal class KeyboardHookConsoleUI : ConsoleUI
    {
        private const int KEY_TO_RETURN = 27; // ESC
        private ExtendedKeyboardHook keyboardHook = null;
        private ExtendedMouseHook mouseHook = null;

        public KeyboardHookConsoleUI(ExtendedKeyboardHook keyboardHook, ExtendedMouseHook mouseHook)
        {
            this.keyboardHook = keyboardHook;
            this.mouseHook = mouseHook;
            this.keyboardHook.Sequences.Add((char)KEY_TO_RETURN, new ActionSequence() { new MenuVisibilityAction() });
        }

        public void MainMenu()
        {
            Layout();

            ManageSequences();
        }

        private void ManageSequences()
        {
            Layout();

            ListSequences();

            PrintMenu("Add", "Delete", "Exit");

            switch (GetInput())
            {
                case 1: AddSequence(); break;
                case 2: DeleteSequence(); break;
                case 3: Application.Exit(); break;
                default: ManageSequences(); break;
            }
        }

        private void AddSequence()
        {
            Layout();

            Console.WriteLine("Input an event key for the sequence: ");
            var key = Console.ReadLine().ToUpper()[0];
            var sequence = new ActionSequence();

            while (true)
            {
                Console.WriteLine("Input an action: ");

                var phrase = Console.ReadLine();
                var action = ActionCreator.Create(phrase, keyboardHook);
                sequence.Add(action);

            addAnotherActionLabel:
                Console.WriteLine("Add another action? (y/n) ");
                var answer = Console.ReadLine();
                if (answer == "y")
                    continue;
                else if (answer == "n")
                    break;
                else
                    goto addAnotherActionLabel;
            }
            if (!keyboardHook.Sequences.ContainsKey(key))
            {
                keyboardHook.Sequences.Add(key, sequence);
                mouseHook.Sequences.Add(key, sequence);
            }  

            ManageSequences();
        }
        private void DeleteSequence()
        {
            Layout();

            ListSequences();

            Console.WriteLine("Input the index of a sequence to delete: ");
            var input = GetInput();

            try
            {
                var sequenceToRemove = keyboardHook.Sequences.ElementAt(input);
                keyboardHook.Sequences.Remove(sequenceToRemove);
                mouseHook.Sequences.Remove(sequenceToRemove);
            }
            catch
            {
                Console.WriteLine("No elements found at this index: " + input);
                Anykey();
            }

            ManageSequences();
        }
        private void ListSequences()
        {
            if (keyboardHook.Sequences.Count == 0)
            {
                Console.WriteLine("No sequences found.");
                Console.WriteLine();
            }
            else
            {
                var counter = 0;
                foreach (var sequence in keyboardHook.Sequences)
                {
                    Console.WriteLine("Index: " + counter.ToString());
                    Console.WriteLine("Key: " + sequence.Key.ToString());
                    Console.WriteLine("Actions: ");
                    Console.WriteLine(sequence.Value.ToString());

                    counter++;
                }
            }
        }

        protected override void Layout()
        {
            base.Layout();
            Console.WriteLine("Press " + ((Keys)KEY_TO_RETURN).ToString() + " to hide or show the window.");
            Console.WriteLine();
        }
    }
}
