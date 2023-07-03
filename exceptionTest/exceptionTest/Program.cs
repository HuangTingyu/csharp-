using System;

namespace exceptionTest
{
    public class Calculator
    {
        public int devide(int numerator, int denomenator)
        {
            return numerator / denomenator;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var calculator = new Calculator();
                var result = calculator.devide(5, 0);
            } catch (Exception)
            {
                Console.WriteLine("Test exception");
            }
        }
    }
}
