using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class MovementBackwardCalculator : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map)
        {
            
            (int, int) nuoveCoordinate = TuplaCreator(command, myRover); ;

            
            if (!map.ElencoOstacoli.Contains(nuoveCoordinate))
            {

                if (nuoveCoordinate.Item1 >= map.LarghezzaMappa)
                {
                    nuoveCoordinate.Item1 = 0;
                }
                else if (nuoveCoordinate.Item1 < 0)
                {
                    nuoveCoordinate.Item1 = map.LarghezzaMappa - 1;
                }
                else if (nuoveCoordinate.Item2 >= map.AltezzaMappa)
                {
                    nuoveCoordinate.Item2 = 0;
                }
                else if (nuoveCoordinate.Item2 < 0)
                {
                    nuoveCoordinate.Item2 = map.AltezzaMappa - 1;
                }

                return (nuoveCoordinate.Item1, nuoveCoordinate.Item2, myRover.Coordinates.Direzione, false);

            }
            else
            {
                return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY, myRover.Coordinates.Direzione, true);
            }
          
        }

        public (int, int) TuplaCreator(char command, Rover myRover)
        {
            if (command == 'B' && myRover.Coordinates.Direzione == 'N')
            {
                return (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY + 1);
            }

            else if (command == 'B' && myRover.Coordinates.Direzione == 'S')
            {
                return  (myRover.Coordinates.CoordinataX, myRover.Coordinates.CoordinataY - 1);
            }
            else if (command == 'B' && myRover.Coordinates.Direzione == 'E')
            {
                return  (myRover.Coordinates.CoordinataX - 1, myRover.Coordinates.CoordinataY);
            }
            else
            {
                return  (myRover.Coordinates.CoordinataX + 1, myRover.Coordinates.CoordinataY);
            }
        }


    }
}
