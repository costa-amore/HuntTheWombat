using Xunit;

namespace HuntTheWombat.core.tests
{

    public class WhenHunterMovesInADirection: AaaStyleTest   
    {
        #region arrange
        private Location previousLocation;
        private Passage direction;
        private Adventure adventure;
        private Hunter hunter;

        protected override void Arrange()
        {
            direction = Passage.RandomDirection();
            adventure = new Adventure();
            hunter = adventure.CreateHunter();

            previousLocation = adventure.HunterLocation;
        }
        #endregion

        protected override void Act() { hunter.Move(direction); }

        [Fact]
        public void HuntersNewLocationShouldBe_OnePositionFurtherInMovedDirection()
        {
            Assert.Equal(previousLocation.Move(1, direction), adventure.HunterLocation);
        }
        [Fact]
        public void HuntersNewLocationShouldBe_ADiscoveredRoom()
        {
            Assert.True(Room.Discovered(adventure.HunterRoom));
        }
    }
}
