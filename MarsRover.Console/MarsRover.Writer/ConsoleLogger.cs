using MarsRover.MapCore;
using MarsRover.Model;

namespace MarsRover.Writer
{
    public class ConsoleLogger : Audit
    {
        public override void Log(Rover myRover, MapDrawer map)
        {
            map.MapPositionDrawer(myRover.Coordinates.Direzione, myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, myRover.Coordinates.Stuck);
        }
    }
}
