using MarsRover.MapCore;
using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Writer
{
    public class ConsoleLogger : Audit
    {
        public override void Log(Rover myRover)
        {
            MapDrawer.MapPositionDrawer(myRover.Coordinates.Direzione, myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, myRover.Coordinates.Stuck);
        }
    }
}
