### class用法

```c#
public class Point
        {
            public int x;
            public int y;
        }

        public static void DrawPoint(Point point) =>
            Console.WriteLine($"坐标点x:{point.x}, y:{point.y}");
            

        static void Main(string[] args)
        {
            Point a = new Point();
            a.x = 15;
            a.y = 10;
            DrawPoint(a);


            Console.Read();
        }
```



### 定义class中的方法

记住，class里的方法不用加static

```c#
public class Point
        {
            public int x;
            public int y;

            public void DrawPoint()
            {
                Console.WriteLine($"坐标点x:{x}, y:{y}");
            }
            

            public double GetDistance(Point p)
            {
                return Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2));
            }
            
        }
```

调用部分

```c#
static void Main(string[] args)
        {
            Point a = new Point();
            a.x = 15;
            a.y = 10;
            a.DrawPoint();

            Point b = new Point();
            b.x = 20;
            b.y = 30;
            Console.WriteLine(a.GetDistance(b));


            Console.Read();
        }
```



### 构造函数

```c#
public class Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void DrawPoint()
            {
                Console.WriteLine($"坐标点x:{x}, y:{y}");
            }
            

            public double GetDistance(Point p)
            {
                return Math.Sqrt(Math.Pow(x - p.x, 2) + Math.Pow(y - p.y, 2));
            }
            
        }
```

调用

```c#
static void Main(string[] args)
        {
            Point a = new Point(10, 15);
            a.DrawPoint();

            Point b = new Point(15, 20);
            Console.WriteLine(a.GetDistance(b));


            Console.Read();
        }
```



### private

定义`private` 变量

```
public class Point
        {
            private int x;
            private int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public void SetX(int value)
            {
                if (value < 0)
                {
                    throw new Exception("value应大于0");
                }
                this.x = value;
            }

            public int GetX()
            {
                return x;
            }

            public void SetY(int value)
            {
                if (value < 0)
                {
                    throw new Exception("value应大于0");
                }
                this.y = value;
            }

            public int GetY()
            {
                return y;
            }
            
        }
```

调用`private`变量

```c#
static void Main(string[] args)
        {
            Point a = new Point(10, 15);
            a.DrawPoint();
            a.SetX(30);
            a.SetY(20);
            int x = a.GetX();
            int y = a.GetY();
            Console.WriteLine($"x_{x},y_{y}");



            Console.Read();
        }
```



### property

新的调用private的方法

注意，这里变量名必须**大写**！

```c#
public class Point
        {
            private int x;
            private int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int X
            {

                get { return x; }
                set {
                    if (value < 0)
                    {
                        throw new Exception("value应大于0");
                    }
                    this.x = value;
                }

            }
}
```

调用

```c#
a.X = 30;
int x = a.X;
Console.WriteLine($"x_{x},y_{y}");
```

