using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class RotationRightCalculator : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            if (command == 'R')
            {
                if (actualOrientation == 'N' && command == 'R')
                {
                    return (roverPosition.Item1, roverPosition.Item2, 'E', false);
                }
                else if (actualOrientation == 'E' && command == 'R')
                {
                    return (roverPosition.Item1, roverPosition.Item2, 'S', false); ;
                }
                else if (actualOrientation == 'W' && command == 'R')
                {
                    return (roverPosition.Item1, roverPosition.Item2, 'N', false);
                }
                else
                {
                    return (roverPosition.Item1, roverPosition.Item2, 'W', false);
                }
            }
            else
            {
                return successor.HandleRequest(command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);
            }
                
        }


    }
}
