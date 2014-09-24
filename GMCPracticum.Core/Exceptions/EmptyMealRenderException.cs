using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace  GCMPracticum.Core.Exceptions
{
    /// <summary>
    /// An excpetion used to indicate that an IMealRender object cannot be constructed without a valid collection of at least 1 IMealMenu object
    /// </summary>
    public class EmptyMealRenderException : Exception
    {
        public EmptyMealRenderException() 
            : base()
        {

        }

        public EmptyMealRenderException(string message) : 
            base(message)
        { 

        }

        public EmptyMealRenderException(SerializationInfo info, StreamingContext context) : 
            base(info,context)
        {

        }

        public EmptyMealRenderException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
