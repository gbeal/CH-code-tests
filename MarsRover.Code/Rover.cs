using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public class Rover : IRover
    {
        private Location _currentLocation;
        private Grid _currentGrid;

        public Location CurrentLocation { get => _currentLocation; }

        public Rover(Grid grid, Location location)
        {
            _currentLocation = location;
            _currentGrid = grid;
        }

        public Rover(Grid grid, int start_x, int start_y, OrdinalDirection start_direction)
        {
            _currentGrid = grid;
            _currentLocation = new Location { CurrentDirection = start_direction, X = start_x, Y = start_y };
        }

        public void AcceptCommand(string command)
        {
            var commandChars = command.ToUpper().ToCharArray();
            foreach(var c in commandChars)
            {
                if(c=='L')
                {
                    _currentLocation = Turn(RelativeDirection.Left);
                }
                else if (c=='R')
                {
                    _currentLocation = Turn(RelativeDirection.Right);
                }
                else if(c=='M')
                {
                    _currentLocation = Move();
                }
            }
        }

        public Location Move()
        {
            Location newLocation = _currentLocation;
            switch (_currentLocation.CurrentDirection)
            {
                case OrdinalDirection.North:
                    newLocation = MoveNorth();
                    break;
                case OrdinalDirection.South:
                    newLocation = MoveSouth();
                    break;
                case OrdinalDirection.East:
                    newLocation = MoveEast();
                    break;
                case OrdinalDirection.West:
                    newLocation = MoveWest();
                    break;
            }

            return newLocation;
        }

        public Location Turn(RelativeDirection direction)
        {
            var newLocation = new Location
            {
                CurrentDirection = GetNewDirection(direction),
                X = _currentLocation.X,
                Y = _currentLocation.Y
            };

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


        private Location MoveNorth()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = _currentLocation.X,
                Y = (_currentLocation.Y + 1) < _currentGrid.YSize ? _currentLocation.Y + 1 : _currentGrid.YSize
            };
        }

        private Location MoveSouth()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = _currentLocation.X,
                Y = (_currentLocation.Y - 1) > _currentGrid.Min_Y ? _currentLocation.Y - 1 : _currentGrid.Min_Y
            };
        }

        private Location MoveWest()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = (_currentLocation.X - 1) > _currentGrid.Min_X ? _currentLocation.X - 1 : _currentGrid.Min_X,
                Y = _currentLocation.Y
            };
        }

        private Location MoveEast()
        {
            return new Location
            {
                CurrentDirection = _currentLocation.CurrentDirection,
                X = (_currentLocation.X + 1) < _currentGrid.XSize ? _currentLocation.X + 1 : _currentGrid.XSize,
                Y = _currentLocation.Y
            };
        }
    }
}
