using System;

namespace Hello
{
    internal class Program
    {
        

        

        static string[] words = new string[]
        {
            "Test", // 0  ^3
            "csharp",// 1 ^2
            "Array" // 2 ^1
        };
 

        static void Main(string[] args)
        {
            Point a = new Point(0,0);
            //Console.WriteLine(a[0]);
            //a[0] = "change";
            //Console.WriteLine(a[0]);
            a.Delta = 15;
            a.PrintDelta();


            //Range p = 0..2;
            //string[] list = words[p];
            //for(int i=0; i<list.Length; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}
            //Console.WriteLine(words[1]);
            //Index k = ^1;
            //Console.WriteLine(words[k]);
            //Point a = new Point(10, 15);
            //a.DrawPoint();
            //a.X = 30;
            //a.SetY(20);
            //int x = a.X;
            //int y = a.GetY();
            //Console.WriteLine($"x_{x},y_{y}");



            Console.Read();
        }
    }
}
