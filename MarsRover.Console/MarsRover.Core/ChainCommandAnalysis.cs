using MarsRover.ChainHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{

    public static class ChainCommandAnalysis
    {

        public static (int, int, char, bool) NewCoordinates(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            //Gestisci rotazione
            MovementHandler r1 = new RotationLeftCalculator();
            MovementHandler r2 = new RotationRightCalculator();
            MovementHandler r3 = new MovementForwardCalculator();
            MovementHandler r4 = new MovementBackwardCalculator();

            r1.SetSuccessor(r2);
            r2.SetSuccessor(r3);
            r3.SetSuccessor(r4);

            //faccio partire catena
            return r1.HandleRequest(command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);


        }
         
        

    }


    



	

   

    

    


}
