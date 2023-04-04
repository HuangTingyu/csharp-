using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashDisk
{
    public class FlashDisk : Computer.SDK.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("32G u盘");
        }

        public void Read()
        {
            Console.WriteLine("读取u盘数据");
        }

        public void Write()
        {
            Console.WriteLine("写入u盘数据");
        }
    }
}
