using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class RotationHandler : MovementHandler
    {
        public override (int, int, char, bool) HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            if (command == 'L' || command == 'R')
            {
                //Gestisci rotazione
                RotationCalculator r1 = new RotationLeftCalculator();
                RotationCalculator r2 = new RotationRightCalculator();

                r1.SetSuccessor(r2);

                //faccio partire catena
                return r1.HandleRequest(command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);
            }
            else if (successor != null)
            {
                return successor.HandleRequest(command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);
            }
        }
    }
}
