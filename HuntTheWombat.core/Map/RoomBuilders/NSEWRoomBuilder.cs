namespace HuntTheWombat.core
{
    internal class NSEWRoomBuilder : IRoomBuilder
    {
        public Room DiscoverRoom(Location hunterLocation)
        {
            return new Room(hunterLocation);
        }
    }
}