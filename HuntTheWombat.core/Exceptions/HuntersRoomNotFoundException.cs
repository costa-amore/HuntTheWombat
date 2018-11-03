using System;
using System.Runtime.Serialization;

namespace HuntTheWombat.core
{
    [Serializable]
    internal class HuntersRoomNotFoundException : Exception
    {
        public HuntersRoomNotFoundException()
        {
        }

        public HuntersRoomNotFoundException(string message) : base(message)
        {
        }

        public HuntersRoomNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HuntersRoomNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}