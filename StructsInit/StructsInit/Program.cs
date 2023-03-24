using HelloWord;
using System;

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

    public class Utility<T> where T : IComparable
    {
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
        static void Main(string[] args)
        {
            //var numberlist = new List();
            var numberlist = new GenericList<int>();
            numberlist.Add(1);

            //var productlist = new ProductList();
            var productlist = new GenericList<Product>();
            productlist.Add(new Product()
            {
                Id = 1,
                Price = 100
            });

            var database = new Dictionary<string, Product>();
            database.Add("123", new Product() { Id = 2, Price = 100 });
            database.Add("234", new Product() { Id = 3, Price = 200 });
            database.Add("456", new Product() { Id = 4, Price = 300 });

            Product product = database.Get("123");
            Console.WriteLine(product.Price);

            //System.Collections.Generic.Dictionary

            Console.Read();
            //Game game;
            //game.name = "pokemon";
            //game.developer = "Jeremy";
            //game.releaseDate = DateTime.Today;

            //game.GetInfo();
            //Console.WriteLine("Hello World!");
        }
    }
}
