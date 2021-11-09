using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class MovementBackwardCalculator : MovementCalculator
    {
        public override void HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            if (command == 'B' && actualOrientation == 'N')
            {
                return (roverPosition.Item1, roverPosition.Item2 + 1);
            }

            else if (command == 'B' && actualOrientation == 'S')
            {
                return (roverPosition.Item1, roverPosition.Item2 - 1);
            }
            else if (command == 'B' && actualOrientation == 'E')
            {
                return (roverPosition.Item1 - 1, roverPosition.Item2);
            }
            else
            {
                return (roverPosition.Item1 + 1, roverPosition.Item2);
            }
        }


    }
}
