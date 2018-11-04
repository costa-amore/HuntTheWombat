namespace HuntTheWombat.core
{
    public class Adventure
    {
        #region construction
        private readonly Map map;

        public Adventure():this(new NSEWRoomBuilder()) { }
        public Adventure(IRoomBuilder roomBuilder)
        {
            HunterLocation = new NoLocation();
            map = new Map(roomBuilder);
        }
        #endregion

        public Location HunterLocation { get; private set; }
        public Room HunterRoom { get { return map.FindRoomBy(HunterLocation); } }
        public Map Map => map;

        public int HunterLife { get { return Hunter.Health; } }

        public Hunter CreateHunter()
        {
            var hunter = new Hunter(this);
            HunterLocation = new Location(0, 0);
            Map.AddRoomAt(HunterLocation);

            return hunter;
        }

        public void HunterMovesThrough(Passage passage) { HunterLocation = Move(HunterLocation, passage); }

        #region Hunter Moves around 
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