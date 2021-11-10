namespace MarsRover.Model
{
    public class MissionStatus
    {
        public string Status;
        public Rover MyRover;

        public MissionStatus(string status, Rover rover)
        {
            Status = status;
            MyRover = rover;

        }


    }
}
