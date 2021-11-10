using MarsRover.MapCore;
using MarsRover.Model;

namespace MarsRover.Writer
{
    public interface IAudit
    {
        void Log(Rover myRover, MapDrawer map );
    }
}
