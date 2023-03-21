### Structs

定义

```c#
struct Game
    {
        public string name;
        public string developer;
        public DateTime releaseDate;

        public void GetInfo()
        {
            Console.WriteLine($"游戏名称： {name}");
            Console.WriteLine($"developer： {developer}");
            Console.WriteLine($"date： {releaseDate}");
        }
    }
```

调用

```c#
static void Main(string[] args)
        {
            Game game;
            game.name = "pokemon";
            game.developer = "Jeremy";
            game.releaseDate = DateTime.Today;

            game.GetInfo();
            Console.WriteLine("Hello World!");
        }
```

#### `struct` 优点

保存在栈内存中，运行效率高

<img src="..\image\Struct\struct_advantage0.png" alt="struct_advantage0" style="zoom:30%;" />

#### `struct` 限制

不支持继承和抽象

不能创建不带参数的默认构造方法，如下所示，创建构造函数时，要把所有的字段都定义都带在参数里，并且都定义一遍。

```c#
struct Game
    {

        public Game (string name, string developer, DateTime date)
        {
            this.name = name;
            this.developer = developer;
            this.releaseDate = date;
        }
}
```

不能访问没定义过的字段，如下所示，会编译不过

```c#
Game game;
game.GetInfo(); // 该方法用了没定义过的字段，会报错
game.name = "pokemon";
game.developer = "Jeremy";
game.releaseDate = DateTime.Today;
```



### 泛型

（1）number类型的List

```c#
public class List
    {
        public void Add(int number)
        {
            throw new NotImplementedException();
        }

        public int this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
```

调用

```c#
var numberlist = new List();
numberlist.Add(1);
```

（2）Product类型的List

```c#
public class ProductList
    {
        public void Add(Product order)
        {
            throw new NotImplementedException();
        }

        public Product this[int index]
        {
            get { throw new NotImplementedException(); }
        }
    }
```

```c#
var productlist = new ProductList();
productlist.Add(new Product()
            {
                Id = 1,
                Price = 100
            });
```

将以上两种类型整合成泛型

这里的`T` 只是一个占位符，没有特殊含义，改成别的字母也可以

```c#
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
```

调用泛型

```c#
var numberlist = new GenericList<int>();
numberlist.Add(1);

var productlist = new GenericList<Product>();
            productlist.Add(new Product()
            {
                Id = 1,
                Price = 100
            });
```

