using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello
{
    public partial class Point
    {
        public int Delta { get; set; }
        public void PrintDelta()
        {
            Console.WriteLine("测试partial");
        }
    }
}
