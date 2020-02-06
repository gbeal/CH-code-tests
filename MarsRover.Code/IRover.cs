using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public interface IRover : IMovable, ICommandable
    {
        Location CurrentLocation { get; }
    }
}
