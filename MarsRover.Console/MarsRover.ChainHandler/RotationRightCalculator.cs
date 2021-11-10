using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class RotationRightCalculator : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map)
        {
            if (command == 'R')
            {
                if (myRover.Coordinates.Direzione == 'N' && command == 'R')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'E', false);
                }
                else if (myRover.Coordinates.Direzione == 'E' && command == 'R')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'S', false); ;
                }
                else if (myRover.Coordinates.Direzione == 'W' && command == 'R')
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'N', false);
                }
                else
                {
                    return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, 'W', false);
                }
            }
            else
            {
                return successor.HandleRequest(command, myRover, map);
            }
                
        }


    }
}
