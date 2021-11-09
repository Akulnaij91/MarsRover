using MarsRover.MapCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Writer
{
    public class ConsoleLogger : Audit
    {
        public override void Log(int x, int y, char direction)
        {
            MapDrawer.MapPositionDrawer(direction, x, y);
        }
    }
}
