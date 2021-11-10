using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class MovementBackwardCalculator : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            
            (int, int) nuoveCoordinate = TuplaCreator(command, roverPosition, actualOrientation); ;

            
            if (!elencoOstacoli.Contains(nuoveCoordinate))
            {

                if (nuoveCoordinate.Item1 >= larghezzaMappa)
                {
                    nuoveCoordinate.Item1 = 0;
                }
                else if (nuoveCoordinate.Item1 < 0)
                {
                    nuoveCoordinate.Item1 = larghezzaMappa - 1;
                }
                else if (nuoveCoordinate.Item2 >= altezzaMappa)
                {
                    nuoveCoordinate.Item2 = 0;
                }
                else if (nuoveCoordinate.Item2 < 0)
                {
                    nuoveCoordinate.Item2 = altezzaMappa - 1;
                }

                return (nuoveCoordinate.Item1, nuoveCoordinate.Item2, actualOrientation, false);

            }
            else
            {
                return (roverPosition.Item1, roverPosition.Item2, actualOrientation, true);
            }
          
        }

        public (int, int) TuplaCreator(char command, (int, int) roverPosition, char actualOrientation)
        {
            if (command == 'B' && actualOrientation == 'N')
            {
                return (roverPosition.Item1, roverPosition.Item2 + 1);
            }

            else if (command == 'B' && actualOrientation == 'S')
            {
                return  (roverPosition.Item1, roverPosition.Item2 - 1);
            }
            else if (command == 'B' && actualOrientation == 'E')
            {
                return  (roverPosition.Item1 - 1, roverPosition.Item2);
            }
            else
            {
                return  (roverPosition.Item1 + 1, roverPosition.Item2);
            }
        }


    }
}
