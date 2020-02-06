using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public class MarsRover : IRover
    {
        private Location _currentLocation;
        private Grid _currentGrid;

        public Location CurrentLocation { get => _currentLocation; }

        public MarsRover(Grid grid, Location location)
        {
            _currentLocation = location;
            _currentGrid = grid;
        }

        public MarsRover(Grid grid, int start_x, int start_y, OrdinalDirection start_direction)
        {
            _currentGrid = grid;
            _currentLocation = new Location { CurrentDirection = start_direction, X = start_x, Y = start_y };
        }

        public void AcceptCommand(string command)
        {
            throw new NotImplementedException();
        }

        public Location Move()
        {
            switch (_currentLocation.CurrentDirection)
            {
                case OrdinalDirection.North:
                    _currentLocation = MoveNorth();
                    break;
                case OrdinalDirection.South:
                    _currentLocation = MoveSouth();
                    break;
                case OrdinalDirection.East:
                    _currentLocation = MoveEast();
                    break;
                case OrdinalDirection.West:
                    _currentLocation = MoveWest();
                    break;
            }
        }

        public Location Turn(RelativeDirection direction)
        {
            var newLocation = new Location
            {
                CurrentDirection = GetNewDirection(direction),
                X = _currentLocation.X,
                Y = _currentLocation.Y
            };

            _currentLocation = newLocation;
            return newLocation;
        }

        private OrdinalDirection GetNewDirection(RelativeDirection direction)
        {
            if (direction == RelativeDirection.Left)
            {
                if (_currentLocation.CurrentDirection == OrdinalDirection.East)
                {
                    return OrdinalDirection.North;
                }
                if (_currentLocation.CurrentDirection == OrdinalDirection.North)
                {
                    return OrdinalDirection.West;
                }
                if (CurrentLocation.CurrentDirection == OrdinalDirection.West)
                {
                    return OrdinalDirection.South;
                }
                if (CurrentLocation.CurrentDirection == OrdinalDirection.South)
                {
                    return OrdinalDirection.East;
                }
            }
            else if (direction == RelativeDirection.Right)
            {
                if (_currentLocation.CurrentDirection == OrdinalDirection.East)
                {
                    return OrdinalDirection.South;
                }
                if (_currentLocation.CurrentDirection == OrdinalDirection.North)
                {
                    return OrdinalDirection.East;
                }
                if (CurrentLocation.CurrentDirection == OrdinalDirection.West)
                {
                    return OrdinalDirection.North;
                }
                if (CurrentLocation.CurrentDirection == OrdinalDirection.South)
                {
                    return OrdinalDirection.West;
                }
            }

            //somehow you're not turning at all..
            return _currentLocation.CurrentDirection;
        }

        }

        private Location MoveNorth()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = _currentLocation.X,
                Y = Math.Max(_currentLocation.Y + 1, _currentGrid.YSize)
            };
        }

        private Location MoveSouth()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = _currentLocation.X,
                Y = Math.Max(_currentLocation.Y - 1, 0)
            };
        }

        private Location MoveWest()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = Math.Max(_currentLocation.X - 1, 0),
                Y = _currentLocation.Y
            };
        }

        private Location MoveEast()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = Math.Max(_currentLocation.X + 1, _currentGrid.XSize),
                Y = _currentLocation.Y
            };
        }
    }
}
