using MarsRover.Model;
using System.Collections.Generic;

namespace MarsRover.ChainHandler
{
    public class RotationLeftCalculator : MovementHandler
    {
        private Dictionary<char, char> _rotationLeftOrientation = new Dictionary<char, char>
        {
            {'N','W' },{'E','N'},{'W','S'},{'S','E'}
        };
        public override (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map)
        {
            if (command=='L')
            {
                return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY,
                    _rotationLeftOrientation.GetValueOrDefault(myRover.Coordinates.Direzione), false);
            }          
            else
            {
                return successor.HandleRequest(command, myRover, map);
            }
        }
    }
}
