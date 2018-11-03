using System.Collections.Generic;

namespace HuntTheWombat.core.tests
{
    internal class MockedRoomBuilder: IRoomBuilder
    {
        #region construction
        private List<Passage> passages;

        public MockedRoomBuilder()
        {
            passages = new List<Passage>
            {
                Passage.North,
                Passage.South,
                Passage.East,
                Passage.West
            };
        }
        #endregion

        #region configure Mock
        internal void NoPassagesIn(Passage passage)
        {
            passages = new List<Passage>();
            if (passage != Passage.North) passages.Add(Passage.North);
            if (passage != Passage.South) passages.Add(Passage.South);
            if (passage != Passage.East) passages.Add(Passage.East);
            if (passage != Passage.West) passages.Add(Passage.West);
        }
        #endregion

        #region mocked behavior
        public Room DiscoverRoom(Location hunterLocation)
        {
            return new Room(hunterLocation, passages);
        }
        #endregion
    }
}
