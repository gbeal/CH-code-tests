using System;
using Xunit;
using Xunit.Abstractions;

using MarsRover.Code;

namespace MarsRover.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test_Rover1Location()
        {
            //set up 5x5 grid
            var grid = new Grid(5, 5);
            //our intended destination
            var intendedLocation = new Location { X = 1, Y = 3, CurrentDirection = OrdinalDirection.North };

            //make it rove
            var rover1 = new Rover(grid, new Location { X = 1, Y = 2, CurrentDirection = OrdinalDirection.North });
            rover1.AcceptCommand("LMLMLMLMM");

            var areSame = intendedLocation == rover1.CurrentLocation;

            Assert.True(rover1.CurrentLocation == intendedLocation);
        }

        [Fact]
        public void Test_Rover2Location()
        {
            //set up 5x5 grid
            var grid = new Grid(5, 5);
            var intendedLocation = new Location { X = 5, Y = 1, CurrentDirection = OrdinalDirection.East };

            var rover2 = new Rover(grid, new Location { X = 3, Y = 3, CurrentDirection = OrdinalDirection.East });
            rover2.AcceptCommand("MMRMMRMRRM");

            Assert.True(rover2.CurrentLocation == intendedLocation);
        }
    }
}
