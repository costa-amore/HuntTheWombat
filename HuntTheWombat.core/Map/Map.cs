using System.Collections.Generic;

namespace HuntTheWombat.core
{
    public class Map
    {
        private readonly Dictionary<Location, Room> Rooms;
        private readonly IRoomBuilder RoomBuilder;

        public Map(IRoomBuilder roomBuilder)
        {
            Rooms = new Dictionary<Location, Room>();
            RoomBuilder = roomBuilder;
        }

        public Room FindRoomBy(Location location)
        {
            if (Rooms.ContainsKey(location))
                return Rooms[location];
            else
                return new UndiscoveredRoom(location);
        }

        public void AddRoomAt(Location location)
        {
            Rooms.Add(location, RoomBuilder.DiscoverRoom(location));
        }

    }
}