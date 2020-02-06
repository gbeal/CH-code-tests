using System;
using System.Collections.Generic;
using System.Linq;

using MarsRover.Code;


namespace MarsRover.Console
{
    using Console = System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            var rover = new InteractiveRover();
            rover.Go();

        }


    }

    class InteractiveRover
    {
        List<string> _directionCommands = new List<string> { "N", "S", "E", "W" };
        List<string> _movementCommands = new List<string> { "L", "R", "M" };
        Location _startingLocation;
        Grid _grid;
        Rover _rover;

        public void Go()
        {
            var tryAgain = true;
            while (tryAgain)
            {
                Intro();

                PromptForGridSize();

                PromptForStartingPosition();

                CreateRover();

                CommandRover();

                Console.WriteLine("Type Q to quit, or any other key to continue");
                var key = Console.ReadKey().KeyChar;
                tryAgain = key.ToString().ToUpper() != "Q";
            }
        }

        public void Intro()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Mars Rover!");
            Console.WriteLine("Start by entering a starting position in the format: X Y {N,S,E,W}");
            Console.WriteLine("Then, valid commands are L, R, M.  L=turn left, R=turn right, M=move forward");
            Console.WriteLine("Press Ctrl-C to exit");

            Console.WriteLine();
        }

        public void PromptForGridSize()
        {
            var badGridSize = true;
            while (badGridSize)
            {
                Console.Write("Enter a grid size: ");
                var gridSizeString = Console.ReadLine();

                var sizes = gridSizeString.Split(" ");
                if (sizes.Length != 2 ||
                    !int.TryParse(sizes[0], out int x) ||
                    !int.TryParse(sizes[1], out int y))
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"'{gridSizeString}' is not valid.  Try something like '5 5' (without quotes)");
                    Console.ForegroundColor = color;
                }
                else
                {
                    _grid = new Grid(x, y);
                    badGridSize = false;
                }
            }
        }

        public bool PromptForStartingPosition()
        {
            var badLocation = true;
            while (badLocation)
            {
                Console.Write("Enter a starting position: ");
                var startingPositionInput = Console.ReadLine();

                var commands = startingPositionInput.Split(" ");
                if (commands.Length != 3 ||
                    !int.TryParse(commands[0], out int x) ||
                    !int.TryParse(commands[1], out int y) ||
                    !_directionCommands.Contains(commands[2].ToUpper()))
                {
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"'{startingPositionInput}' is not valid.  Try something like '2 3 E' (without quotes)");
                    Console.ResetColor();
                }
                else if (x > _grid.XSize)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The starting X value {x} is greater than the Grid X of {_grid.XSize}");
                    Console.ResetColor();
                }
                else if(y> _grid.YSize)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"The starting Y value {y} is greater than the Grid Y of {_grid.YSize}");
                    Console.ResetColor();
                }
                else
                {
                    _startingLocation = new Location { X = x, Y = y, CurrentDirection = GetOrdinalFromString(commands[2]) };
                    badLocation = false;
                }

                
            }

            return true;
        }

        public OrdinalDirection GetOrdinalFromString(string direction)
        {
            switch (direction.ToUpper())
            {
                case "N":
                    return OrdinalDirection.North;
                case "E":
                    return OrdinalDirection.East;
                case "S":
                    return OrdinalDirection.South;
                case "W":
                    return OrdinalDirection.West;
            }
            return OrdinalDirection.North;
        }

        public void CreateRover()
        {
            _rover = new Rover(_grid, _startingLocation);
        }

        public void CommandRover()
        {
            var command = string.Empty;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rover is currently at {_startingLocation}");
            Console.ResetColor();

            Console.WriteLine();
            var badCommand = true;
            while (badCommand)
            {
                Console.Write("Enter command(s) to move the rover.  Available commands are {L,R,M}.");
                var newCommand = Console.ReadLine();

                foreach (var c in newCommand.ToArray())
                {
                    if (_movementCommands.Contains(c.ToString().ToUpper()))
                    {
                        command += c;
                    }
                }
                badCommand = false;

            }

            _rover.AcceptCommand(command);
            command = string.Empty;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Rover is currently at {_rover.CurrentLocation}");
            Console.ResetColor();
        }


    }

}
