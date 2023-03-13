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

            //ConsoleKeyInfo a = Console.ReadKey();
            //Console.WriteLine(a.Key);
            //Console.Clear();
            //Console.Read();
            //Console.WriteLine("My name is {0}.I am {1} years old", "hty", 18);
            string name = "hty";
            int age = 18;
            //string message = "My name is {0}. I am {1} years old.";
            //string output = string.Format(message, name, age);
            //Console.WriteLine(output);
            //string message = $"My name is {name}. I am {age} years old.";
            //Console.WriteLine(message);
            string str = @"test next line";


            //string hello = "hello";
            //string str = hello.ToUpper();
            Console.WriteLine(str);

            Console.Read();
        }
    }
}
