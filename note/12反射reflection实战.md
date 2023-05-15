### 反射的好处

一句话总结，可以通过 `Type.GetType` 动态获得类定义，不用通过new的方式手动定义。

`List.cs`

```c#
namespace ReflectionTest
{
        public class List
        {
            public void Add()
            {
                Console.WriteLine("ddddd");
            }
        }
}
```

调用

```c#
static void Main(string[] args)
        {
    string classLocation = "ReflectionTest.List, ReflectionTest";
    Type objType = Type.GetType(classLocation);
    object obj = Activator.CreateInstance(objType);
    MethodInfo add = objType.GetMethod("Add");
    add.Invoke(obj, null);
}
```



### reflection实战

新建类 `Computer.SDK`

```c#
namespace Computer.SDK
{
    public interface IUSB
    {
        void GetInfo();
        void Read();
        void Write();
    }
}
```



### 生成`dll`文件

关于报错 

```
程序不包含适合于入口点的静态“Main”方法（C#）
```

解决方法，

切换到“解决方案”，右键属性

<img src="..\image\Reflection\property.png" alt="property" style="zoom:30%;" />



输出类型这里改成“类库”

![change_input_type](D:\00工作笔记\csharp_note\image\Reflection\change_input_type.png)



生成  `Computer.SDK` `Ctrl+B`

<img src="D:\00工作笔记\csharp_note\image\Reflection\generate_dll.png" alt="generate_dll" style="zoom:30%;" />



### 新建类`FlashDisk`

右键“解决方案”，点击“新建项目”，点击“类库”，新建类`FlashDisk` 

![add_class](..\image\Reflection\add_class.png)

引入项目依赖，选择`Computer.SDK`

![add_intro](..\image\Reflection\add_intro.png)

右键`FlashDisk` ，添加类`FlashDisk`

```c#
public class FlashDisk : Computer.SDK.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("32G u盘");
        }

        public void Read()
        {
            Console.WriteLine("读取u盘数据");
        }

        public void Write()
        {
            Console.WriteLine("写入u盘数据");
        }
    }
```

生成`FlashDisk` `dll`文件的步骤同上。



### 新建类`SSD`

步骤同上

`SSD.cs`

```c#
public class SSD : Computer.SDK.IUSB
    {
        public void GetInfo()
        {
            Console.WriteLine("1TB固态硬盘");
        }

        public void Read()
        {
            Console.WriteLine("读取固态硬盘");
        }

        public void Write()
        {
            Console.WriteLine("写入固态硬盘");
        }
    }
```

生成`SSD` `dll`文件的步骤同上。



### `dll` 文件的应用

`ReflectionInit\FlashDisk\bin\Debug\net5.0` 找到 `FlashDisk.dll`

`ReflectionInit\SSD\bin\Debug\net5.0` 找到 `SSD.dll`

然后在`ReflectionInit\ReflectionInit\bin\Debug\net5.0` 新建文件夹 `USB` 

将这两个`dll`文件粘贴到刚刚新建的`USB` 目录下



### 获取文件

```c#
static void Main(string[] args)
        {
            string USBInterface = Path.Combine(Environment.CurrentDirectory,"USB"); //获得USB文件夹路径
            Console.WriteLine(USBInterface);
            var dllFiles = Directory.GetFiles(USBInterface);

            var deviceList = new List<IUSB>();
            // 读取dllFiles中的文件
            foreach (var dll in dllFiles)
            {
                var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dll); // 获取dll文件
                var typeList = assembly.GetTypes(); //获取dll文件类型列表
                // 检查类型是否正确
                foreach (var type in typeList)
                {
                    var interfaceList = type.GetInterfaces(); //获取dll里各种类的接口
                    foreach (var i in interfaceList)
                    {
                        if (i.Name == "IUSB")
                        {
                            var usb = (IUSB)Activator.CreateInstance(type);
                            deviceList.Add(usb);
                        }
                    }
                }
            }

            foreach (var usb in deviceList)
            {
                usb.GetInfo();
                usb.Read();
                usb.Write();
            }
        }
```

