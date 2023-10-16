using System;
using System.Runtime.Serialization;

namespace Exceptions{
    [Serializable]
    internal class InvalidRegistrationCityException : Exception
    {
        public InvalidRegistrationCityException()
        {
        }

        public InvalidRegistrationCityException(string message) : base(message)
        {
        }

        public InvalidRegistrationCityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRegistrationCityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}