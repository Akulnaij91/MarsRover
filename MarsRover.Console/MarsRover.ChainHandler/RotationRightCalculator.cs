using MarsRover.Model;
using System.Collections.Generic;

namespace MarsRover.ChainHandler
{
    public class RotationRightCalculator : MovementHandler
    {
        private Dictionary<char, char> _rotationRightOrientation = new Dictionary<char, char>
        {
            {'N','E' },{'E','S'},{'W','N'},{'S','W'}
        };
        public override (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map)
        {
            if (command == 'R')
            {
                return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY,
                    _rotationRightOrientation.GetValueOrDefault(myRover.Coordinates.Direzione), false);
            }
            else
            {
                return successor.HandleRequest(command, myRover, map);
            }
                
        }


    }
}
