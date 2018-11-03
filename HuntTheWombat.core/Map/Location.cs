namespace HuntTheWombat.core
{
    public class Location
    {
        #region construction
        private readonly int x_Position;
        private readonly int y_Position;

        public Location(int x_Position, int y_Position)
        {
            this.x_Position = x_Position;
            this.y_Position = y_Position;
        }
        #endregion

        public Location Move(int nrOfPositions, Passage direction)
        {
            if (direction == Passage.North) return new Location(x_Position,                 y_Position + nrOfPositions  );
            if (direction == Passage.South) return new Location(x_Position,                 y_Position - nrOfPositions  );
            if (direction == Passage.East)  return new Location(x_Position + nrOfPositions, y_Position                  );
            if (direction == Passage.West)  return new Location(x_Position - nrOfPositions, y_Position                  );

            throw new UnsupportedDirectionException();
        }

        public override string ToString() { return "Location (x:" + x_Position + " y:" + y_Position + ")"; }

        #region equality
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;

            if (this.x_Position != ((Location)obj).x_Position) return false;
            if (this.y_Position != ((Location)obj).y_Position) return false;

            return true;
        }

        public override int GetHashCode()
        {
            var result = 0;
            result = (result * 397) ^ x_Position;
            result = (result * 397) ^ y_Position;
            return result;
        }
        #endregion

        #region private parts
        #endregion
    }

    public class NoLocation : Location
    {
        #region contructor
        public NoLocation() : base(int.MinValue, int.MinValue) { }
        #endregion

        #region Equality
        public override bool Equals(object obj)
        {
            if (obj == null ) return false;

            return GetType() == obj.GetType();
        }

        public override int GetHashCode()
        {
            return int.MinValue;
        }
        #endregion
    }
}