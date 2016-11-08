using HookSample.Core;
using HookSample.Core.Actions;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HookSample.UI
{
    public class KeyboardHookConsoleUI : ConsoleUI
    {
        private const int KEY_TO_RETURN = 27; // ESC
        private ExtendedKeyboardHook hook = null;

        public KeyboardHookConsoleUI(ExtendedKeyboardHook hook)
        {
            this.hook = hook;
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

            PrintMenu("Add", "Delete", "Back");

            switch (GetInput())
            {
                case 1: AddSequence(); break;
                case 2: DeleteSequence(); break;
                case 3: MainMenu(); break;
            }
        }

        private void AddSequence()
        {
            Layout();

            Console.WriteLine("Input an event key for the sequence: ");
            var key = GetInput();
            var sequence = new ActionSequence();

            while (true)
            {
                Console.WriteLine("Input an action: ");

                var phrase = Console.ReadLine();
                var action = ActionCreator.Create(phrase);
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

            hook.Sequences.Add(key, sequence);

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
                var sequenceToRemove = hook.Sequences.ElementAt(input);
                hook.Sequences.Remove(sequenceToRemove);
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
            if (hook.Sequences.Count == 0)
            {
                Console.WriteLine("No sequences found.");
                Console.WriteLine();
            }
            else
            {
                var counter = 0;
                foreach (var sequence in hook.Sequences)
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
