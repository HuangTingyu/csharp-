### 构造可用的exe

```
Console.Read();
```

加上这句话以后，命令行窗口就不会一闪而过。命令行窗口会停住，等待用户输入。



### `System.Console`

### `Console.Write`

`Console.Write` 输出的字符不换行

`Console.WriteLine` 输出以后自动换行



### `Console.Read`

`Console.Read` 读取输入的第一个字符，读取的是ASCII码，例如输入A，然后回车，显示65

```
int opt = Console.Read();
Console.WriteLine(opt);
Console.Read();
```



### `Console.ReadLine`

读取输入的字符串

```
string str = Console.ReadLine();
Console.WriteLine(str);
Console.Read();
```



### `Console.ReadKey`

可以读取回车操作

```
ConsoleKeyInfo a = Console.ReadKey();
Console.WriteLine(a.Key);
Console.Read();
```



### `Console.Clear()`

清空屏幕