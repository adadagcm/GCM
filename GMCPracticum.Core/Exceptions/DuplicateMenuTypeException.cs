using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace  GCMPracticum.Core.Exceptions
{
    /// <summary>
    /// An excpetion used to indicate that multiple menus of the same type are being added to a IMealRender object
    /// </summary>
    public class DuplicateMenuTypeException : Exception
    {
        public DuplicateMenuTypeException() 
            : base()
        {

        }

        public DuplicateMenuTypeException(string message) : 
            base(message)
        { 

        }

        public DuplicateMenuTypeException(SerializationInfo info, StreamingContext context) : 
            base(info,context)
        {

        }

        public DuplicateMenuTypeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
