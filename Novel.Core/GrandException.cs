using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Novel.Core
{
    [Serializable]
    public class GrandException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the Exception class.
        /// </summary>
        public GrandException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Exception class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public GrandException(string message)
            : base(message)
        {
        }

    }
}
