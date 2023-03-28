### 反射写法

```c#
public class Excel
        {
            public string Table { get; set; }
            public void ShowTable()
            {
                Console.WriteLine("打印excel表格");
            }
        }
```

正常写法

```
var excel = new Excel();
excel.ShowTable();
// 这里excel不能再赋值成其他
// 错误写法 excel = "123";
```



反射写法

```
object excel = new Excel();
 
var methodInfo = excel.GetType().GetMethod("ShowTable");
methodInfo.Invoke(excel, null); //这里的null表示的是传入ShowTable中的参数
Console.Read();
```

此处`GetType` 先获得`excel`的类型，`GetMethod` 获得`excel` 中的方法。



`dynamic` 写法

```
dynamic excel = new Excel();
excel.ShowTable();
// 此时excel可以赋值成其他
excel = "123";
```

