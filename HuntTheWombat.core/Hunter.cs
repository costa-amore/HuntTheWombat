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
            Health = 10;
        }
        #endregion

        public static int Health { get; internal set; }

        public void Move(Passage passage) { adventure.HunterMovesThrough(passage); }
    }
}