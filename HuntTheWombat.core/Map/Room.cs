using System.Collections.Generic;

namespace HuntTheWombat.core
{
    public class Room
    {
        public static bool Discovered(Room room) { return room.discovered;}

        #region constructor
        private readonly Location location;
        private readonly List<Passage> passages;
        protected bool discovered;

        public Room(Location hunterLocation):this(hunterLocation, new List<Passage>
            {
                Passage.North,
                Passage.South,
                Passage.East,
                Passage.West
            })
        { }

        public Room(Location location, List<Passage> passages)
        {
            this.location = location;
            this.passages = passages;
            this.discovered = true;

        }
        #endregion

        public bool Has(Passage passage) { return passages.Contains(passage); }

        internal Location LocationOfRoomBehind(Passage passage) { return location.Move(1, passage); }
    }

    public class UndiscoveredRoom : Room
    {
        public UndiscoveredRoom(Location hunterLocation) : this(hunterLocation, new List<Passage>())
        {
        }

        public UndiscoveredRoom(Location hunterLocation, List<Passage> passages) : base(hunterLocation, passages)
        {
            base.discovered = false;
        }
    }
}