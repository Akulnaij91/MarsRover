using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class MissionStatus
    {
        public string Status;
        public Rover myRover;

        public MissionStatus(string status, Rover rover)
        {
            Status = status;
            myRover = rover;

        }


    }
}
