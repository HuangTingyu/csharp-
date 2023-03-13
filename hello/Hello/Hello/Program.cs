using System;

namespace Hello
{
    internal class Program
    {
        public static int FindMax(int num1, int num2)
        {
            int result;
            if(num1> num2)
            {
                result = num1;
            } else
            {
                result = num2;
            }

            return result;
        }

        static void swap(int x, int y)
        {
            int temp;
            temp = x;
            x = y;
            y = temp;
        }

        static void getValue(out int x)
        {
            x = 5;
        }


        static void Main(string[] args)
        {
            //Console.WriteLine("Hello .Net Core!");
            //int output = FindMax(1, 99);
            int a = 100;
            int b = 500;

            //swap(a, b);
            //Console.WriteLine($"a:{a},b:{b}");
            getValue(out a);
            Console.WriteLine($"a:{a}");

            Console.Read();
        }
    }
}
