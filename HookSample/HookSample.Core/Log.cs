//
// Yuri Vetroff
// yuri.vetroff@gmail.com
//

using System;
using System.IO;
using System.Windows.Forms;

namespace HookSample.Core
{
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
        private Log() { }
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

        /// <summary>
        /// Gets or sets the path to the log file.
        /// </summary>
        public string Filename { get; set; } = "log.txt";

        /// <summary>
        /// Writes the the specified text to the log.
        /// </summary>
        /// <param name="text">The text to write.</param>
        public void Write(string text)
        {
            // Gets the current time in hh.mm.ss format.
            var time = DateTime.Now.ToLongTimeString();
            // Adds the time to the text string (before the text).
            text = time + " - " + text;
            // Opens the log file and writes the text.
            try
            {
                // Creates a stream writer and writes the text.
                using (var writer = new StreamWriter(Filename, true))
                    writer.WriteLine(text);
            }
            catch { }
        }
    }
}
