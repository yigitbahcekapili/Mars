using Mars.ConsoleApp.Helper;
using Mars.ConsoleApp.Interfaces;

namespace Mars.ConsoleApp
{
    public class Rover
    {
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Direction { get; set; }
        public IWorkingArea WorkingArea { get; set; }


        public void Move(string movement)
        {
            if (movement != Movement.Move)
            {
                ChangeDirection(movement);
                return;
            }

            SetRoverCoordinate();
        }

        private void SetRoverCoordinate()
        {
            if (Direction == Compass.North && YCoordinate != WorkingArea.YCoordinate)
            {
                YCoordinate += 1;
            }
            else if (Direction == Compass.South && YCoordinate != 0)
            {
                YCoordinate -= 1;
            }
            else if (Direction == Compass.East && XCoordinate != WorkingArea.XCoordinate)
            {
                XCoordinate += 1;
            }
            else if (Direction == Compass.West && XCoordinate != 0)
            {
                XCoordinate -= 1;
            }
        }

        private void ChangeDirection(string movement)
        {
            Direction = Compass.GetCompassDirection(Direction, movement);
        }
    }
}