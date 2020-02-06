using System;
using Xunit;

using MarsRover.Code;

namespace MarsRover.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_RoverLocation()
        {
            //set up 5x5 grid
            var grid = new Grid(5, 5);

            IRover rover1 = new MarsRover(new Location { X=1, Y=2, CurrentDirection=OrdinalDirection.North });
            rover1.AcceptCommand("LMLMLMLMM");

            IRover rover2 = new MarsRover(new Location { X = 3, Y = 3, CurrentDirection = OrdinalDirection.East });
            rover2.AcceptCommand("LMLMLMLMM");



            Assert.True(rover1.CurrentLocation == new Location { X = 1, Y = 3, CurrentDirection = OrdinalDirection.North });
            Assert.True(rover2.CurrentLocation == new Location { X = 5, Y = 1, CurrentDirection = OrdinalDirection.East });


        }
    }
}
