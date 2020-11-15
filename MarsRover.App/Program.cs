using MarsRover.App.Model.Concrete;
using System;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***Mars Rover App*****");
            Console.WriteLine();
            Console.WriteLine("Plateau 5 5");
            Console.WriteLine("Rover Position 1 2 N");
            Console.WriteLine("input: LMLMLMLMM");
            Console.WriteLine();
            Console.WriteLine("Expected Output:1 3 N");
            Console.WriteLine("MMRMMRMRRM");
            Console.WriteLine();

            Plateau plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(1, 2), Direction.N);
            rover.Run("LMLMLMLMM");

            Console.WriteLine();
            Console.WriteLine("Output "+ rover.LastRoverPosition());
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
