using MarsRover.Model;


namespace MarsRover.ChainHandler
{
    public abstract class MovementHandler
    {
        protected MovementHandler successor;
        public void SetSuccessor(MovementHandler successor)
        {
            this.successor = successor;
        }
        public abstract (int, int, char, bool) HandleRequest(char command, Rover myRover, MapInformation map);
    }
}
