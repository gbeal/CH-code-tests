using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public OrdinalDirection CurrentDirection { get; set; }
    }

    public enum OrdinalDirection
    {
        North,
        South,
        East,
        West
    }

    public enum RelativeDirection
    {
        Left,
        Right
    }
}
