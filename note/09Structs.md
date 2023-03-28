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

`System.Collections.Generic`

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



### 泛型经典类型：字典

`System.Collections.Generic.Dictionary`



### 泛型类型限制

泛型可以被限制为，接口，class，struct或者new()

```c#
// where T : IComparable
// where T : class(product类, 或者product派生类book)
// where T : struct
// where T : new () 表示该泛型类必须包含构造方法
```



写法1

```c#
public class Utility
    {
        public int FindMax(int a, int b)
        {
            return a > b ? a : b;
        }

        public T FindMax<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
```

写法2

```c#
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
```

带构造函数的写法 `new()`

```c#
public class Utility<T> where T : IComparable, new()
    {
        public void DoSomething()
        {
            var obj = new T();
        }
}
```



限制参数类型为struct， struct类型的变量不能为空

如果有要创建struct类型的变量，又要变量可以赋值为空，可以使用以下的class

```c#
public class Nullable<T> where T:struct
    {
        private object _value;

        public Nullable(){} // 加了这一行，可以不用传value

        public Nullable(T value)
        {
            _value = value;
        }
        //判断value是否为空
        public bool HasValue
        {
            get {
                return _value != null;
            }
        }

        // 获取T默认值
        public T GetValueOrDefault()
        {
            if (HasValue)
            {
                // 如果T类型的_value有值，那返回_value
                return (T)_value;
            }
            // 否则返回T类型的默认值
            return default(T);
        }
    }
```

使用类`Nullable`

```c#
// 不传参数
Nullable<int> number = new Nullable<int>();
var numberDefault = number.GetValueOrDefault();
Console.WriteLine(number.HasValue);
Console.WriteLine(numberDefault);

// 传参数
var number2 = new Nullable<int>(5);
var number2Default = number2.GetValueOrDefault();
Console.WriteLine(number2Default);
```

