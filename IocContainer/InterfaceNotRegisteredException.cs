using System;
using System.Runtime.Serialization;

namespace IocContainer
{
    [Serializable]
    public class InterfaceNotRegisteredException : Exception
    {
        public InterfaceNotRegisteredException()
        {
        }

        public InterfaceNotRegisteredException(string message) : base(message)
        {
        }

        public InterfaceNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InterfaceNotRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
