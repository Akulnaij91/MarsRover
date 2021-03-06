using MarsRover.ChainHandler;
using MarsRover.Model;

namespace MarsRover.Core
{

    public static class ChainCommandAnalysis
    {

        public static (int X, int Y, char Oriented, bool Stuck) NewCoordinates(char command, Rover myRover, MapInformation map)
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
            return r1.HandleRequest(command, myRover, map);
        }
         
        

    }


    



	

   

    

    


}
