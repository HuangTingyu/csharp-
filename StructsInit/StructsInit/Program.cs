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
