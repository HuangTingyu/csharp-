using System;

namespace Hello
{
    internal class Program
    {
        public class Point
        {
            private int x;
            private int y;
            public string[] gamma = new string[]
        {
            "Test", // 0  ^3
            "csharp",// 1 ^2
            "Array" // 2 ^1
        };

            public string this[int index]
            {
                get
                {
                    return gamma[index];
                }
                set
                {
                    gamma[index] = value;
                }
            }

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {

                get { return x; }
                set {
                    if (value < 0)
                    {
                        throw new Exception("value应大于0");
                    }
                    this.x = value;
                }

            }
             

            public void SetY(int value)
            {
                if (value < 0)
                {
                    throw new Exception("value应大于0");
                }
                this.y = value;
            }

            public int GetY()
            {
                return y;
            }

            public void DrawPoint()
            {
                Console.WriteLine($"坐标点x:{x}, y:{y}");
            }
            

            public double GetDistance(Point p)
            {
                return Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2));
            }
            
        }

        static string[] words = new string[]
        {
            "Test", // 0  ^3
            "csharp",// 1 ^2
            "Array" // 2 ^1
        };
 

        static void Main(string[] args)
        {
            Point a = new Point(0,0);
            Console.WriteLine(a[0]);
            a[0] = "change";
            Console.WriteLine(a[0]);


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
