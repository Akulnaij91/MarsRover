using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace MarsRover.MapCore
{
    public class MapDrawer
    {
        public int _larghezzaMappa;
        public readonly int _altezzaMappa;
        public readonly List<(int, int)> _arrayTupleOstacoli =
            new()
            {
                  (1, 0),
                  (5, 5),
                  (1, 9),
                  (7, 4),
                  (6, 2)
              };
        public readonly char _initialDirection;
        public readonly int _initialRoverX;
        public readonly int _initialRoverY;

        public MapDrawer(int larghezzaMappa, int altezzaMappa, List<(int,int)> ostacoli, char initialDirection, int initialX, int initialY)
        {
            _larghezzaMappa = larghezzaMappa;
            _altezzaMappa = altezzaMappa;
            _arrayTupleOstacoli = ostacoli;
            _initialDirection = initialDirection;
            _initialRoverX = initialX;
            _initialRoverY = initialY;
        }


        public void MapPositionDrawer(char actualRoverDirection, int actualRoverX, int actualRoverY, bool stuck)
        {
            CreaMappa(_larghezzaMappa, _altezzaMappa, actualRoverDirection, actualRoverX, actualRoverY, _arrayTupleOstacoli, stuck);
        }


        public void MapInitializer()
        {
            CreaMappa(_larghezzaMappa, _altezzaMappa, _initialDirection, _initialRoverX, _initialRoverY, _arrayTupleOstacoli,false);
        }



        public void CreaRiga(int numColonne, int x, bool rigaVuota, char direction, int rigaattuale, List<(int, int)> ostacoli)
        {
            string rigaTop = "";
            string rigaMiddle = "";
            string rigaBottom = "";
            string top = "┌───┐";
            string middleEmpty = "│   │";
            string middleObstacle = "│┼┼┼│";
            string middleFull = "│ ▼ │";
            string bottom = "└───┘";

            if (direction == 'N')
            {
                middleFull = "│ ▲ │";
            }
            else if (direction == 'E')
            {
                middleFull = "│ ► │";

            }
            else if (direction == 'W')
            {
                middleFull = "│ ◄ │";
            }

            for (int a = 0; a < numColonne; a++)
            {
                rigaTop += top;
                if (a == x && !rigaVuota)
                {
                    rigaMiddle += middleFull;
                }
                else
                {
                    var tupla = (a, rigaattuale);
                    if (ostacoli.Contains(tupla))
                    {
                        rigaMiddle += middleObstacle;
                    }
                    else
                    {
                        rigaMiddle += middleEmpty;
                    }
                }
                rigaBottom += bottom;
            }
            Console.WriteLine(rigaTop);
            Console.WriteLine(rigaMiddle);
            Console.WriteLine(rigaBottom);
        }


        public void CreaMappa(int numColonne, int numRighe, char direction, int x, int y, List<(int, int)> ostacoli, bool stuck)
        {
            var direzione = "North";
            if (direction == 'S')
            {
                direzione = "South";
            } else if (direction == 'E')
            {
                direzione = "East";
            } else if (direction == 'W')
            {
                direzione = "West";
            }
            var status = "Everything is fine!";
            if (stuck)
            {
                status = "HOUSTON WE HAVE A PROBLEM!";
            }
            Console.WriteLine($"GPS Scan of Mars Planet - {DateTime.Now}");
            Console.WriteLine($"Rover coord: {x},{y} - Facing: {direzione}");
            Console.WriteLine($"Status: {status}");
            for (var i = 0; i < numRighe; i++)
            {
                if (i == y)
                {
                    CreaRiga(numColonne, x, false, direction, i, ostacoli);
                }
                else
                {
                    CreaRiga(numColonne, x, true, direction, i, ostacoli);
                }
            }
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Environment.NewLine);
        }
    }
}
