namespace HuntTheWombat.core
{
    public class Adventure
    {
        #region construction
        private readonly Map Map;

        public Adventure():this(new NSEWRoomBuilder()) { }
        public Adventure(IRoomBuilder roomBuilder)
        {
            HunterLocation = new NoLocation();
            Map = new Map(roomBuilder);
        }
        #endregion

        public Location HunterLocation { get; private set; }
        public Room HunterRoom { get { return Map.FindRoomBy(HunterLocation); } }

        public Hunter CreateHunter()
        {
            var hunter = new Hunter(this);
            HunterLocation = new Location(0, 0);
            Map.AddRoomAt(HunterLocation);

            return hunter;
        }

        #region Hunter Moves around 
        internal void HunterMovesThrough(Passage passage) { HunterLocation = Move(HunterLocation, passage); }

        private Location Move(Location fromLocation, Passage passage)
        {
            if (!Room.Discovered(Map.FindRoomBy(fromLocation))) throw new HuntersRoomNotFoundException();

            var room = Map.FindRoomBy(fromLocation);
            if (!room.Has(passage)) return fromLocation; // hunter walked into a wall :)

            var toLocation = room.LocationOfRoomBehind(passage);
            Map.AddRoomAt(toLocation);

            return toLocation;
        }
        #endregion
    }
}