using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace  GCMPracticum.Core.Exceptions
{
    /// <summary>
    /// A exception that indicates a invalid menu type is attempting to be created
    /// </summary>
    public class InvalidMenuTypeException : Exception
    {
        public InvalidMenuTypeException() 
            : base()
        {

        }

        public InvalidMenuTypeException(string message) : 
            base(message)
        { 

        }

        public InvalidMenuTypeException(SerializationInfo info, StreamingContext context) : 
            base(info,context)
        {

        }

        public InvalidMenuTypeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
