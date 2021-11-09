using System;
using System.Collections.Generic;

namespace MarsRover.ChainHandler
{
    public abstract class MovementHandler
    {
        protected MovementHandler successor;
        public void SetSuccessor(MovementHandler successor)
        {
            this.successor = successor;
        }
        public abstract (int, int, char, bool) HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa);
    }
}
