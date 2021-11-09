using System;
using System.Collections.Generic;

namespace MarsRover.Model
{
    public interface IRobot
    {
        List<(int,int)> GetCoordinates();

        char GetDirection();
    }
}
