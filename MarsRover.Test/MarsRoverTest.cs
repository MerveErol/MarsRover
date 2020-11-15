using MarsRover.App;
using MarsRover.App.Helper;
using System;
using Xunit;
using MarsRover.App.Model.Concrete;

namespace MarsRover.Test
{
    public class MarsRoverTest
    {

        [Fact]
        public void Should_FirstRoverInMars_Success_Result()
        {
            //Given
            Plateau plateauOne = new Plateau(new Position(5, 5));
            Rover firstRover = new Rover(plateauOne, new Position(1, 2), Direction.N);

            // Act
            firstRover.Run("LMLMLMLMM");

            //Assert
            Assert.Equal("1 3 N", firstRover.LastRoverPosition());
        }

        [Fact]
        public void Should_SecondRoverInMars_Success_Result()
        {
            //Given
            Plateau plateauTwo = new Plateau(new Position(5, 5));
            Rover secondRover = new Rover(plateauTwo, new Position(3, 3), Direction.E);

            // Act
            secondRover.Run("MMRMMRMRRM");

            //Assert
            Assert.Equal("5 1 E", secondRover.LastRoverPosition());
        }

        [Fact]
        public void Should_TwoRoverInMars_Success_Result()
        {
            //Given
            Plateau plateau = new Plateau(new Position(5, 5));
            Rover firstRover = new Rover(plateau, new Position(1, 2), Direction.N);
            Rover secondRover = new Rover(plateau, new Position(3, 3), Direction.E);

            // Act
            firstRover.Run("LMLMLMLMM");
            secondRover.Run("MMRMMRMRRM");

            //Assert
            Assert.Equal("1 3 N", firstRover.LastRoverPosition());
            Assert.Equal("5 1 E", secondRover.LastRoverPosition());
        }

        [Fact]
        public void Should_ArgumentException_When_OutBoundsInput()
        {
            //Given
            Plateau plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(5, 2), Direction.N);

            // Act
            var ex = Assert.ThrowsAny<ArgumentException>(() => rover.Run("RMRMRMMM"));

            //Assert
            Assert.Equal("You cannot go beyond the boundaries of Plateau", ex.Message);
        }

        [Fact]
        public void Should_ArgumentException_When_IncorrectInput()
        {
            //Given
            Plateau plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(1, 2), Direction.N);

            // Act
            var ex = Assert.ThrowsAny<ArgumentException>(() => rover.Run("LMAMMM"));

            //Assert
            Assert.Equal("Invalid value: A", ex.Message);
        }

        [Fact]
        public void Should_ArgumentNullException_When_NullCommandInput()
        {
            //Given
            Plateau plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(1, 2), Direction.N);

            // Act
            var ex = Assert.ThrowsAny<ArgumentException>(() => rover.Run(null));

            //Assert
            Assert.Equal("Value cannot be null. (Parameter 'commands')", ex.Message);
        }

        [Fact]
        public void Should_ArgumentNullException_When_EmptyCommandInput()
        {
            //Given
            Plateau plateau = new Plateau(new Position(5, 5));
            Rover rover = new Rover(plateau, new Position(1, 2), Direction.N);

            // Act
            var ex = Assert.ThrowsAny<ArgumentException>(() => rover.Run(string.Empty));

            //Assert
            Assert.Equal("command cannot be empty", ex.Message);
        }

        [Theory]
        [InlineData(90)]
        public void Should_DegreeToRadian_Success_Result(int degree)
        {
            // Act
            double radianResult = DegreeToRadian.Get(degree);

            //Assert
            Assert.Equal(1.5707963267948966, radianResult);
        }
    }
}
