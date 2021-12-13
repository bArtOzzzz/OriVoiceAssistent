using System;
using System.Collections.Generic;

namespace Ori_Assistent
{
    public class Commands
    {
        /// <summary>
        /// Command 1 | Hello
        /// </summary>
        public static List<string> command1 = new List<string>
        {
            "Hi", "glad to see you",
        };

        /// <summary>
        /// Command 2 | How are you
        /// </summary>
        public static List<string> command2 = new List<string>
        {
            "I am working normally", "And how do I know"
        };

        /// <summary>
        /// Command 3 | What time is it
        /// </summary>
        public static List<string> command3 = new List<string>
        {
            $"{DateTime.Now: h mm tt yy}"
        };

        /// <summary>
        /// Command 4 | Stop talking
        /// </summary>
        public static List<string> command4 = new List<string>
        {
            "OK", "Fine, I will be quite"
        };

        /// <summary>
        /// Command 5 | Stop listening
        /// </summary>
        public static List<string> command5 = new List<string>
        {
            "if you need me just ask"
        };

        /// <summary>
        /// Command 6 | Thank you
        /// </summary>
        public static List<string> command6 = new List<string>
        {
            "No problems", "I am glad to help you", "You will have to"
        };

        /// <summary>
        /// Command 7 | Cancel
        /// </summary>
        public static List<string> command7 = new List<string>
        {
            "Cancellation successful", "Canceling the operation", "Canceled successfully", "Operation was cancelled"
        };

        /// <summary>
        /// Command 8 | Exceptions logo
        /// </summary>
        public static List<string> command8 = new List<string>
        {
            "Operation cannot be performed", "Unable to execute command"
        };

        /// <summary>
        /// Command 9 | Key word - Ori
        /// </summary>
        public static List<string> command9 = new List<string>
        {
            "I'm here", "I'm waiting for commands", "What do we do"
        };

        /// <summary>
        /// Command 10 | OK
        /// </summary>
        public static List<string> command10 = new List<string>
        {
            "Ok", "No problems", "I will do"
        };
    }
}
