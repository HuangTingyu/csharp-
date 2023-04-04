using System;

namespace StructsInit
{
    public class List
    {
        public void Add()
        {
            Console.WriteLine("test reflection");
        }

        public int this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
}
