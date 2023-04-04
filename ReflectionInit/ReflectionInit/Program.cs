using System;
using System.IO;
using System.Collections.Generic;
using Computer.SDK;
using System.Runtime.Loader;

namespace ReflectionInit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string USBInterface = Path.Combine(Environment.CurrentDirectory,"USB"); //获得USB文件夹路径
            Console.WriteLine(USBInterface);
            var dllFiles = Directory.GetFiles(USBInterface);

            var deviceList = new List<IUSB>();
            // 读取dllFiles中的文件
            foreach (var dll in dllFiles)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll); // 获取dll文件
                var typeList = assembly.GetTypes(); //获取dll文件类型列表
                // 检查类型是否正确
                foreach (var type in typeList)
                {
                    var interfaceList = type.GetInterfaces(); //获取dll里各种类的接口
                    foreach (var i in interfaceList)
                    {
                        if (i.Name == "IUSB")
                        {
                            var usb = (IUSB)Activator.CreateInstance(type);
                            deviceList.Add(usb);
                        }
                    }
                }
            }

            foreach (var usb in deviceList)
            {
                usb.GetInfo();
                usb.Read();
                usb.Write();
            }
        }
    }
}
