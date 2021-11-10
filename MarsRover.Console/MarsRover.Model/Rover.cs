namespace MarsRover.Model
{
    public class Rover : IRobot
    {
        public string Name;
        public CoordinateRover Coordinates;
        public string MissionStatus;

        public Rover(string nome, CoordinateRover coord)
        {
            Name = nome;
            Coordinates = coord;
        }

        public string RememberMyName()
        {
            return Name;
        }
        public CoordinateRover GetCoordinates()
        {
            return Coordinates;
        }

     

       
    }
}
