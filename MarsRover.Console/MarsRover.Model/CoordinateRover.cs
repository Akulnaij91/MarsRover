namespace MarsRover.Model
{
    public class CoordinateRover
    {
        public int CoordinataX;
        public int CoordinataY;
        public char Direzione;
        public bool Stuck;

        public CoordinateRover(int x, int y, char dir, bool stuck=false)
        {
            CoordinataX = x;
            CoordinataY = y;
            Direzione = dir;
            Stuck = stuck;
        }
    }
}
