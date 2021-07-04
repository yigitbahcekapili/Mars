using Mars.ConsoleApp.Helper;
using Mars.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mars.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            var p = new Program();

            Plateau plateau = p.SetPlateauCoordinate();

            var roverList = new Dictionary<Rover, List<string>>();

            while (true)
            {
                Rover rover = p.SendNewRover(plateau);

                var roverMovements = p.GetRoverMovementList();

                roverList.Add(rover, roverMovements);

                Console.WriteLine("Please enter X to move or anything to add new rover");

                var moveControl = Console.ReadLine().ToUpper();

                if (moveControl == "X") break;
            }

            foreach (var rover in roverList)
            {
                foreach (var movement in rover.Value)
                {
                    rover.Key.Move(movement);
                }

                Console.WriteLine($"X : {rover.Key.XCoordinate} \nY : {rover.Key.YCoordinate} \nDirection : {rover.Key.Direction}");
            }

        }


        public Plateau SetPlateauCoordinate()
        {
            var plateau = new Plateau();
            Console.WriteLine("Enter plateau coordinates : ");

            while (true)
            {
                var plateauInput = Console.ReadLine().ToUpper().Split(' ').ToList();

                if (plateauInput.Count == 2 &&
                    int.TryParse(plateauInput[0], out int xCoordinate) &&
                    int.TryParse(plateauInput[1], out int yCoordinate))
                {
                    plateau.XCoordinate = xCoordinate;
                    plateau.YCoordinate = yCoordinate;

                    break;
                }

                Console.WriteLine("Please enter the plateau coordinates as 2 integers");
            }

            return plateau;
        }

        public Rover SendNewRover(IWorkingArea workingArea)
        {
            var rover = new Rover();

            while (true)
            {
                Console.WriteLine("Enter rover coordinates : ");

                var roverInput = Console.ReadLine().ToUpper().Split(' ').ToList();

                if (roverInput.Count != 3)
                {
                    Console.WriteLine("You must enter x and y coordinate and compass direction");
                    continue;
                }

                bool roverXCoordinateIsValid = int.TryParse(roverInput[0], out int xCoordinate);
                bool roverYCoordinateIsValid = int.TryParse(roverInput[1], out int yCoordinate);

                if (roverXCoordinateIsValid == false || roverYCoordinateIsValid == false)
                {
                    Console.WriteLine("You must enter the coordinates as integers");
                    continue;
                }

                if (xCoordinate > workingArea.XCoordinate || xCoordinate < 0 || yCoordinate > workingArea.YCoordinate && yCoordinate < 0)
                {
                    Console.WriteLine("Rover coordinates must not be greater than plateau coordinates");
                    continue;
                }

                if (roverInput[2] != Compass.East && roverInput[2] != Compass.West && roverInput[2] != Compass.South && roverInput[2] != Compass.North)
                {
                    Console.WriteLine("Rover direction must be entered as E, W, N or S");
                    continue;
                }

                rover.Direction = roverInput[2];
                rover.XCoordinate = Convert.ToInt32(roverInput[0]);
                rover.YCoordinate = Convert.ToInt32(roverInput[1]);
                rover.WorkingArea = workingArea;

                break;
            }

            return rover;
        }

        public List<string> GetRoverMovementList()
        {
            var movementList = new List<string>();

            while (true)
            {
                Console.WriteLine("Please enter rover movement information: ");

                movementList = Console.ReadLine().ToUpper().Select(x => x.ToString()).ToList();

                var movementControl = movementList.Any(x => x != Movement.Left && x != Movement.Right && x != Movement.Move);

                if (movementControl == false) break;

                Console.WriteLine("Rover movement information must be entered as L, R or M");
            }

            return movementList;
        }

    }
}
