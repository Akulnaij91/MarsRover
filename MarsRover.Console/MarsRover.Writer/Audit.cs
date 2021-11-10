using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Writer
{
    public abstract class Audit : IAudit
    {
        public abstract void Log(Rover rover);
    }
}
