using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    internal class InvalidProdusCantitateException : Exception
    {
        public InvalidProdusCantitateException()
        {
        }

        public InvalidProdusCantitateException(string message) : base(message)
        {
        }

        public InvalidProdusCantitateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidProdusCantitateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}