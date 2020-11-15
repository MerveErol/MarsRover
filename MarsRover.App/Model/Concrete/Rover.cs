using MarsRover.App.Helper;
using MarsRover.App.Model.Absract;
using System;

namespace MarsRover.App.Model.Concrete
{
    public class Rover : IRover
    {
        public IPlateau RoverPlateau { get; set; }
        public IPosition RoverPosition { get; set; }
        public Direction RoverDirection { get; set; }

        public Rover(IPlateau roverPlateau, IPosition roverPosition, Direction roverDirection)
        {
            RoverPlateau = roverPlateau ?? throw new ArgumentNullException(nameof(roverPlateau));
            RoverPosition = roverPosition ?? throw new ArgumentNullException(nameof(roverPosition));
            RoverDirection = roverDirection;
        }

        public void Run(string commands)
        {
            CheckCommands(commands);

            CommandProcess(commands);
        }

        private static void CheckCommands(string commands)
        {
            if (commands == null)
                throw new ArgumentNullException(nameof(commands));

            if (commands == string.Empty)
                throw new ArgumentException("command cannot be empty");
        }

        private void CommandProcess(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case ('L'):
                        LeftRotate();
                        break;
                    case ('R'):
                        RightRotate();
                        break;
                    case ('M'):
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format("Invalid value: {0}", command));
                }
            }
        }

        /// <summary>
        /// Moving left 90 degrees means +90 in the coordinate plane
        /// </summary>
        private void LeftRotate()
        {
            RoverDirection += 90;
            RoverDirection = (Direction)((int)RoverDirection % 360);
        }

        /// <summary>
        /// Moving 90 degrees to the right means -90 in the coordinate plane.
        /// </summary>
        private void RightRotate()
        {
            RoverDirection -= 90;
            if (RoverDirection < 0)
            {
                RoverDirection += 360;
            }
        }

        /// <summary>
        /// This method calculates new position that is calculated with rover’s direction degree.
        /// The sin(y) and cos(x) methods operate in radians.
        /// 
        /// Cos(x)-->x Type: Radian
        /// Sin(y)-->y Type: Radian
        /// </summary>
        private void Move()
        {
            var radian = DegreeToRadian.Get((int)RoverDirection);

            RoverPosition.XCoordinate += (int)Math.Round(Math.Cos(radian));
            RoverPosition.YCoordinate += (int)Math.Round(Math.Sin(radian));

            RoverPlateau.IsHasWithinBounds(RoverPosition);
        }

        public string LastRoverPosition()
        {
            return string.Format("{0} {1} {2}", RoverPosition.XCoordinate, RoverPosition.YCoordinate, RoverDirection);
        }
    }
}