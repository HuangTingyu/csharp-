using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD
{
    public class SSD : Computer.SDK.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("1TB固态硬盘");
        }

        public void Read()
        {
            Console.WriteLine("读取固态硬盘");
        }

        public void Write()
        {
            Console.WriteLine("写入固态硬盘");
        }
    }
}
