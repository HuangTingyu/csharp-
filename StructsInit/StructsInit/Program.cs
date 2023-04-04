using System;
using System.Reflection;

namespace StructsInit
{
    struct Game
    {
        public string name;
        public string developer;
        public DateTime releaseDate;

        public Game (string name, string developer, DateTime date)
        {
            this.name = name;
            this.developer = developer;
            this.releaseDate = date;
        }

        public void GetInfo()
        {
            Console.WriteLine($"游戏名称： {name}");
            Console.WriteLine($"developer： {developer}");
            Console.WriteLine($"date： {releaseDate}");
        }
    }

    public class GenericList<T>
    {
        public void Add(T order)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }

    // where T : IComparable
    // where T : class(product, book)
    // where T : struct
    // where T : new ()

    public class Utility<T> where T : IComparable, new()
    {
        public void DoSomething()
        {
            var obj = new T();
        }

        public int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }

        public T FindMax(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }


    internal class Program
    {

        public class Excel
        {
            public string Table { get; set; }
            public void ShowTable()
            {
                Console.WriteLine("打印excel表格");
            }
        }
        static void Main(string[] args)
        {
            //var numberlist = new List();
            //var numberlist = new GenericList<int>();
            //numberlist.Add(1);

            //var productlist = new ProductList();
            //var productlist = new GenericList<Product>();
            //productlist.Add(new Product()
            //{
            //    Id = 1,
            //    Price = 100
            //});

            //var database = new Dictionary<string, Product>();
            //database.Add("123", new Product() { Id = 2, Price = 100 });
            //database.Add("234", new Product() { Id = 3, Price = 200 });
            //database.Add("456", new Product() { Id = 4, Price = 300 });

            //Product product = database.Get("123");
            //Console.WriteLine(product.Price);

            //System.Collections.Generic.Dictionary

            //Nullable<int> number = new Nullable<int>();
            //var numberDefault = number.GetValueOrDefault();
            //Console.WriteLine(number.HasValue);
            //Console.WriteLine(numberDefault);

            //var number2 = new Nullable<int>(5);
            //var number2Default = number2.GetValueOrDefault();
            //Console.WriteLine(number2Default);

            //Game game;
            //game.name = "pokemon";
            //game.developer = "Jeremy";
            //game.releaseDate = DateTime.Today;

            //game.GetInfo();
            //Console.WriteLine("Hello World!");
            //Nullable<DateTime> date = null;
            //DateTime? date = null;
            //DateTime? date = new DateTime(2023, 5, 5);
            //DateTime date2 = date.GetValueOrDefault();
            //DateTime? date3 = date2;
            //if (date3.HasValue)
            //{
            //    Console.WriteLine(date3.GetValueOrDefault());
            //} else
            //{
            //    Console.WriteLine(DateTime.Today);
            //}
            //var result = date3 ?? DateTime.Today;
            //Console.WriteLine(result);

            //Console.WriteLine(date.GetValueOrDefault());
            //Console.WriteLine(date.HasValue);

            //Console.WriteLine(date.value);
            //dynamic excel = new Excel();
            // 反射写法
            //dynamic excel = new Excel();
            //excel.ShowTable();
            //var methodInfo = excel.GetType().GetMethod("ShowTable");
            //methodInfo.Invoke(excel, null);
            string classLocation = "StructsInit.List, StructsInit";
            Type objType = Type.GetType(classLocation); //获得类型
            object obj = Activator.CreateInstance(objType); // 创建实例
            MethodInfo add = objType.GetMethod("Add"); // 获得类中的方法
            add.Invoke(obj, null); // 调用方法,因为add方法不传参数，所以第二个参数null


            Console.Read();


        }
    }
}
