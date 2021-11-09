using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public class ForwardHandler : MovementHandler
    {
        public override void HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            if (command == 'F' || command == 'B')
            {
                //Gestisci rotazione
                MovementCalculator r1 = new MovementForwardCalculator();
                MovementCalculator r2 = new MovementBackwardCalculator();

                r1.SetSuccessor(r2);

                //faccio partire catena
                r1.HandleRequest(command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);
            }
            else
            {
                throw new Exception("Houston we have A BIG PROBLEM!");
            }
        }
    }
}
