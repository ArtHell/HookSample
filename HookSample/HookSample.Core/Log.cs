//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.IO;

namespace HookSample.Core
{
    /// <summary>
    /// Provides methods and properties for logging.
    /// </summary>
    internal class Log
    {
        #region Singleton members

        /// <summary>
        /// The instance of the Log.
        /// </summary>
        private static Log instance = null;

        /// <summary>
        /// Initializes a new instance of the Log class.
        /// </summary>
        private Log()
        {
        }

        /// <summary>
        /// Gets the instance of the Log.
        /// </summary>
        public static Log Instance
        {
            get
            {
                // Checks if the instance is null.
                if (instance == null)
                    // Creates the instance if yes.
                    instance = new Log();

                // Returns the instance.
                return instance;
            }
        }

        #endregion

        private const string MouseFilename = "mouse_log.txt";

        private const string KeyboardFilename = "keyboard_log.txt";

        private const string AppFilename = "app_log.txt";

        /// <summary>
        /// Writes the mouse log.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteMouseLog(string text)
        {
            Write(text, MouseFilename);
        }

        /// <summary>
        /// Writes the keyboard log.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteKeyboardLog(string text)
        {
            Write(text, KeyboardFilename);
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="text">The text.</param>
        public void WriteAppLog(string text)
        {
            Write(text, AppFilename);
        }

        /// <summary>
        /// Writes the the specified text to the log.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="filename">The filename.</param>
        public void Write(string text, string filename)
        {
            // Gets the current time in hh.mm.ss format.
            var time = DateTime.Now.ToLongTimeString();
            // Adds the time to the text string (before the text).
            text = time + " - " + text;
            // Opens the log file and writes the text.
            try
            {
                // Creates a stream writer and writes the text.
                using (var writer = new StreamWriter(filename, true))
                    writer.WriteLine(text);
            }
            catch
            {
            }
        }
    }
}
