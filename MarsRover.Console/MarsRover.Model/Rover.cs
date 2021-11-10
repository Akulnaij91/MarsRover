using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class Rover : IRobot
    {
        public string Name;
        public CoordinateRover Coordinates;

        public Rover(string nome, CoordinateRover coord)
        {
            Name = nome;
            Coordinates = coord;
        }

        public string RememberMyName()
        {
            return Name;
        }
        public CoordinateRover GetCoordinates()
        {
            return Coordinates;
        }

     

       
    }
}
