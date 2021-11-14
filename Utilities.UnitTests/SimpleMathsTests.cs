using System;
using Xunit;
using Utilities;

namespace Utilities.UnitTests
{
    public class SimpleMathsTests
    {
        private int _precision = 2;

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        [InlineData(3, 3, 6)]
        [InlineData(-1, -1, -2)]
        [InlineData(-2, -2, -4)]
        [InlineData(-3, -3, -6)]
        [InlineData(0.01, 0.02, 0.03)]
        public void Add_CorrectInput_ReturnCorrectAnswer(double x, double y, double expectedValue)
        {
            //Arrange
            //Act
            double actualValue = SimpleMaths.Add(x, y);
            //Assert
            Assert.Equal(expectedValue, actualValue, precision:_precision);
        }


        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(2, 10, -8)]
        [InlineData(76.4, 60.4, 16)]
        [InlineData(-1, -1, 0)]
        [InlineData(-295, -0.01, -294.99)]
        [InlineData(0.01, 0.02, -0.01)]
        public void Subtract_CorrectInput_ReturnCorrectAnswer(double x, double y, double expectedValue)
        {
            //Arrange
            //Act
            double actualValue = SimpleMaths.Subtract(x, y);
            //Assert
            Assert.Equal(expectedValue, actualValue, precision:_precision);
        }

        [Theory]
        [InlineData(500, 10, 5000)]
        [InlineData(-1, 785.65, -785.65)]
        [InlineData(0.01, 0.01, 0.0001)]
        public void Multiply_CorrectInput_ReturnCorrectAnswer(double x, double y, double expectedValue)
        {
            //Arrange
            //Act
            double actualValue = SimpleMaths.Multiply(x, y);
            //Assert
            Assert.Equal(expectedValue, actualValue, precision:_precision);
        }

        [Theory]
        [InlineData(500, 10, 50)]
        [InlineData(-1, 4, -0.25)]
        [InlineData(0.01, 0.01, 1)]
        public void Divide_CorrectInput_ReturnCorrectAnswer(double x, double y, double expectedValue)
        {
            //Arrange
            //Act
            double actualValue = SimpleMaths.Divide(x, y);
            //Assert
            Assert.Equal(expectedValue, actualValue, precision:_precision);
        }

        [Theory]
        [InlineData(1, 0)]
        public void Divide_IncorrectInput_ReturnCorrectAnswer(double x, double y)
        {
            //Arrange
            //Act
            //Assert
            Assert.Throws<DivideByZeroException>(() => SimpleMaths.Divide(x, y));
            
        }
    }
}
