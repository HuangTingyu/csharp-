using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public partial class Point
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
            set
            {
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
}
