using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.ChainHandler
{
    public abstract class RotationCalculator
    {
        protected RotationCalculator successor;
        
        public void SetSuccessor(RotationCalculator successor)
        {
            this.successor = successor;
        }
        public abstract (int, int, char, bool) HandleRequest(char command, (int, int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa);
    }
}
