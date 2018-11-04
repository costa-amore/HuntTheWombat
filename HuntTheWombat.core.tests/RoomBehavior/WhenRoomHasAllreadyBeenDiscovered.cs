using Xunit;

namespace HuntTheWombat.core.tests.RoomBehavior
{
    public class WhenRoomHasAllreadyBeenDiscovered:AaaStyleTest
    {
        #region arrange
        private Adventure adventure;
        private Room room;

        protected override void Arrange()
        {
            adventure = new Adventure();
            var hunter = adventure.CreateHunter();

            adventure.HunterMovesThrough(Passage.South);
            room = adventure.HunterRoom;
        }
        #endregion

        protected override void Act()
        {
            adventure.HunterMovesThrough(Passage.North);
        }

        [Fact]//begin here !
        public void ShouldNotBe_DiscoveredAgainWhenEnteringASecondTime()
        {
            Assert.True(Room.Discovered(room));
        }
    }
}
