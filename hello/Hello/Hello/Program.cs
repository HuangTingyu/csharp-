using System;

namespace Hello
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello .Net Core!");
            //Console.Write("Test");
            //Console.Write(" write!");
            //Console.Read();

            //int opt = Console.Read();
            //Console.WriteLine(opt);
            //Console.Read();

            //string str = Console.ReadLine();
            //Console.WriteLine(str);
            //Console.Read();

            ConsoleKeyInfo a = Console.ReadKey();
            Console.WriteLine(a.Key);
            Console.Clear();
            Console.Read();
        }
    }
}
