using MarsRover.ChainHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{

    public class Test{

        public static (int, int, char, bool) NewCoordinates(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            //Creo catena
            MovementHandler h1 = new RotationHandler();
            MovementHandler h2 = new ForwardHandler();

            h1.SetSuccessor(h2);

            //faccio partire catena
            return h1.HandleRequest( command, roverPosition, actualOrientation, elencoOstacoli, larghezzaMappa, altezzaMappa);


        }
         
        

    }


    



	

   

    

    


}
