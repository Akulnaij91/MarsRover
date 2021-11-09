using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    

    public abstract class MovementCalculator
    {
        protected MovementCalculator successor;

        public void SetSuccessor(MovementCalculator successor)
        {
            this.successor = successor;
        }
        public abstract void HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa);
    }
}
