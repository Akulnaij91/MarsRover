using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class RotationLeftCalculator : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map)
        {
            if (command=='L')
            {
                if (myRover.Coordinates.Direzione == 'N' && command == 'L')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'W', false);
                }
                else if (myRover.Coordinates.Direzione == 'E' && command == 'L')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'N', false);
                }
                else if (myRover.Coordinates.Direzione == 'W' && command == 'L')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'S', false);
                }
                else 
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'E', false);
                }
            }          
            else
            {
                return successor.HandleRequest(command, myRover, map);
            }
        }
    }
}
