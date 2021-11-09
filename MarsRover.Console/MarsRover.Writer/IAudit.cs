using System;

namespace MarsRover.Writer
{
    public interface IAudit
    {
        void Log(int x, int y, char direction);
    }
}
