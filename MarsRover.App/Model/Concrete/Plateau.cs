
using MarsRover.App.Model.Absract;
using System;

namespace MarsRover.App
{
    public class Plateau : IPlateau
    {
        public Position PlateauPosition { get; private set; }

        public Plateau(Position position)
        {
            PlateauPosition = position;
        }

        public bool IsHasWithinBounds(IPosition roverPosition)
        {
            if ((roverPosition.XCoordinate > PlateauPosition.XCoordinate) ||
                (roverPosition.YCoordinate > PlateauPosition.YCoordinate))
                throw new ArgumentException("You cannot go beyond the boundaries of Plateau");

            return true;
        }
    }
}
