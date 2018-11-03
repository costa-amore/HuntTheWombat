using System;
using System.Runtime.Serialization;

namespace HuntTheWombat.core
{
    [Serializable]
    internal class UnsupportedDirectionException : Exception
    {
        public UnsupportedDirectionException()
        {
        }

        public UnsupportedDirectionException(string message) : base(message)
        {
        }

        public UnsupportedDirectionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnsupportedDirectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}