using MarsRover.MapCore;
using MarsRover.Model;

namespace MarsRover.Writer
{
    public abstract class Audit : IAudit
    {
        public abstract void Log(Rover rover, MapDrawer map);
    }
}
