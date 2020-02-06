using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public interface IMovable
    {
        Location Move();
        Location Turn(RelativeDirection direction);
    }
}
