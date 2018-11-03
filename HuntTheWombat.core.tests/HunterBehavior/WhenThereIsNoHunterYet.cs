using Xunit;

namespace HuntTheWombat.core.tests.HunterBahavior
{
    public class WhenThereIsNoHunterYet
    {
        [Fact]
        public void ThereShouldBeNoOneToMove()
        {
            //arrange
            var adventure = new Adventure();

            //assert
            Assert.Equal(new NoLocation(), adventure.HunterLocation);
        }
    }
}
