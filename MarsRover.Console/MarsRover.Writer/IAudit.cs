using MarsRover.Model;
using System;

namespace MarsRover.Writer
{
    public interface IAudit
    {
        void Log(Rover myRover);
    }
}
