using System;

namespace HuntTheWombat.core
{
    public class Passage
    {
        #region threadsafe construction of singletons
        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit (http://csharpindepth.com/Articles/General/Singleton.aspx)
        static Passage() { }

        protected Passage() { }
        #endregion

        #region create direction singletons
        public static Passage North { get; } = new Passage();
        public static Passage South { get; } = new Passage();
        public static Passage East  { get; } = new Passage();
        public static Passage West  { get; } = new Passage();
        #endregion

        #region random direction generator
        public static Passage RandomDirection()
                     { return RandomDirection(new Random()); }
        public static Passage RandomDirection(Random rnd)
        {
            int direction = rnd.Next(4) + 1;

            if (direction == 1) return Passage.North;
            if (direction == 2) return Passage.South;
            if (direction == 3) return Passage.East;

            return Passage.West;
        }
        #endregion

        public Passage Opposite()
        {
            if (this == Passage.North) return Passage.South;
            if (this == Passage.South) return Passage.North;
            if (this == Passage.East) return Passage.West;
            if (this == Passage.West) return Passage.East;

            throw new UnsupportedDirectionException();
        }
    }
}
