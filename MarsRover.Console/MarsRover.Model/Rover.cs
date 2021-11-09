using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class Rover : IRobot
    {
        public string Name = "Curiosity";
        public List<(int,int)> Coordinates;
        public char Direction;

        public List<(int, int)> GetCoordinates()
        {
            return Coordinates;
        }

        public char GetDirection()
        {
            return Direction;
        }

       
    }
}
