using System;

namespace HuntTheWombat.core
{
    public class Hunter
    {
        #region construction
        private readonly Adventure adventure;

        public Hunter(Adventure adventure)
        {
            this.adventure = adventure;
        }
        #endregion

        #region public interface
        public void Move(Passage passage) { adventure.HunterMovesThrough(passage); }
        #endregion
    }
}