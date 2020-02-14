using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public CardinalDirection CurrentDirection { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Location other))
                return false;

            return X == other.X && Y == other.Y && CurrentDirection == other.CurrentDirection;
        }

        public override int GetHashCode()
        {
            return (X, Y, CurrentDirection).GetHashCode();
        }

        public static bool operator== (Location location1, Location location2)
        {
            return location1.Equals(location2);
        }

        public static bool operator !=(Location location1, Location location2)
        {
            return !location1.Equals(location2);
        }


        public override string ToString()
        {
            return $"{X} {Y} {CurrentDirection.ToString()}";
        }
    }
}
