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

新建类`FlashDisk` ，引入项目依赖，选择`Computer.SDK`

![add_intro](..\image\Reflection\add_intro.png)

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





