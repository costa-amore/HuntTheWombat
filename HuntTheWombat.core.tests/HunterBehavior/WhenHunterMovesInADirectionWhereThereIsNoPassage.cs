using Xunit;

namespace HuntTheWombat.core.tests.HunterBahavior
{
    public class WhenHunterMovesInADirectionWhereThereIsNoPassage: AaaStyleTest
    {
        #region arrange
        private Passage direction;
        private Adventure adventure;
        private Hunter hunter;
        private Location previousLocation;

        protected override void Arrange()
        {
            direction = Passage.RandomDirection();
            var mockedRoomBuilder = new MockedRoomBuilder();
            mockedRoomBuilder.NoPassagesIn(direction);

            adventure = new Adventure(mockedRoomBuilder);
            hunter = adventure.CreateHunter();

            hunter.Move(direction);

            previousLocation = adventure.HunterLocation;
        }
        #endregion

        protected override void Act() { hunter.Move(direction); }

        [Fact]
        public void HuntersNewLocationShouldBe_Unchanged()
        {
            Assert.Equal(previousLocation, adventure.HunterLocation);
        }
    }
}
