using System;

namespace Utilities
{
    public static class SimpleMaths
    {
        /// <summary>
        /// Adds two numbers together
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The sum of the two numbers</returns>
        public static double Add(double x, double y)
        {
            return x + y;
        }

        /// <summary>
        /// Subtracts the second number from the first
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The difference of the two numbers</returns>
        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        /// <summary>
        /// Multiplies two numbers together
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The product of the two numbers</returns>
        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        /// <summary>
        /// Divides the first number by the second
        /// </summary>
        /// <param name="x">The first number</param>
        /// <param name="y">The second number</param>
        /// <returns>The quotient of the two numbers</returns>
        public static double Divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }
            
            return x / y;
        }


    }
}
