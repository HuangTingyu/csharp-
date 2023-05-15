using System;
using System.Reflection;

namespace ReflectionTest
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            string classLocation = "ReflectionTest.List, ReflectionTest";
            Type objType = Type.GetType(classLocation);
            object obj = Activator.CreateInstance(objType);
            MethodInfo add = objType.GetMethod("Add");
            add.Invoke(obj, null);
        }
    }
}
