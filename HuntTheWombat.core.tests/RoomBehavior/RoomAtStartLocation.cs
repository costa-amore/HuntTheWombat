using Xunit;

namespace HuntTheWombat.core.tests.RoomBehavior
{
    public class RoomAtStartLocation:AaaStyleTest
    {
        #region arrange
        private Adventure adventure;

        protected override void Arrange()
        {
            adventure = new Adventure();
            var hunter = adventure.CreateHunter();
        }
        #endregion

        [Fact] public void ShouldHave_APassageNorth() { Assert.True(adventure.HunterRoom.Has(Passage.North)); }
        [Fact] public void ShouldHave_APassageSouth() { Assert.True(adventure.HunterRoom.Has(Passage.South)); }
        [Fact] public void ShouldHave_APassageEast()  { Assert.True(adventure.HunterRoom.Has(Passage.East )); }
        [Fact] public void ShouldHave_APassageWest()  { Assert.True(adventure.HunterRoom.Has(Passage.West )); }
    }
}
