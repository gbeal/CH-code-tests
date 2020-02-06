using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public interface ICommandable
    {
        void AcceptCommand(string command);
    }
}
