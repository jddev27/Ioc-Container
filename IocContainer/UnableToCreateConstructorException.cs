using System;
using System.Runtime.Serialization;

namespace IocContainer
{
    [Serializable]
    public class UnableToCreateConstructorException : Exception
    {
        public UnableToCreateConstructorException()
        {
        }

        public UnableToCreateConstructorException(string message) : base(message)
        {
        }

        public UnableToCreateConstructorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnableToCreateConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}