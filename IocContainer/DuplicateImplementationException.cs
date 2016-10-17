using System;
using System.Runtime.Serialization;

namespace IocContainer
{
    [Serializable]
    internal class DuplicateImplementationException : Exception
    {
        public DuplicateImplementationException()
        {
        }

        public DuplicateImplementationException(string message) : base(message)
        {
        }

        public DuplicateImplementationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateImplementationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}