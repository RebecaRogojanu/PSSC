using System;
using System.Runtime.Serialization;

namespace Exceptions{

    [Serializable]
    internal class InvalidRegistrationStreetException: Exception
    {
        public InvalidRegistrationStreetException()
        {
        }

        public InvalidRegistrationStreetException(string message) : base(message)
        {
        }

        public InvalidRegistrationStreetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRegistrationStreetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}