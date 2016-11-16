using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookSample.Core.Actions
{
    public class KeyHideAction : IHookAction
    {
        private Hook hook;

        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 2;

        public KeyHideAction(Hook hook)
        {
            this.hook = hook;
        }


        /// <summary>
        /// Returns a string that represents the StartProcessAction.
        /// </summary>
        /// <returns>A string that represents the StartProcessAction.</returns>
        public override string ToString()
        {

            return "hide";
        }

        public void Execute()
        {
        }
    }
}
