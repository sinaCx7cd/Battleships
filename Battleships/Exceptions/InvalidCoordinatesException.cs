using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Exceptions
{
    public class InvalidCoordinatesException : Exception
    {
        public InvalidCoordinatesException()
        {
        }

        public InvalidCoordinatesException(string? message) : base(message)
        {
        }

        public InvalidCoordinatesException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCoordinatesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
