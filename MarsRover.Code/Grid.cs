﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Code
{
    public class Grid
    {
        public int Min_X => 0;
        public int Min_Y => 0;
        public int XSize { get; }
        public int YSize { get; }
        private Grid()
        { }

        public Grid(int x_size, int y_size)
        {
            XSize = x_size;
            YSize = y_size;
        }
    }
}
