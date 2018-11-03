using Xunit;

namespace HuntTheWombat.core.tests.RoomBehavior
{
    public class WhenTakingAPassageInADirection
    {
        [Fact]
        public void TheRoomEnteredShould_HaveAPassageInTheOppositeDirection()
        {
            //arrange
            var direction = Passage.RandomDirection();
            var adventure = new Adventure();
            var hunter = adventure.CreateHunter();

            //act
            hunter.Move(direction);

            //assert
            Assert.True(adventure.HunterRoom.Has(direction.Opposite()));
        }
    }
}
