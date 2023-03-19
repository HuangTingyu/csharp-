### Ioc反转控制

参考文档

https://learn.microsoft.com/zh-cn/dotnet/core/extensions/dependency-injection



右键解决方案 ”管理`Nuget`程序包“

下载依赖`Microsoft.Extensions.DependencyInjection` ，根据csharp版本选择对应的版本，这里用的是csharp5.0所以选择`5.0.2` 版本。

![install_Nuget](..\image\Nuget\install_Nuget.png)

下载成功后

<img src="..\image\Nuget\install_nuget_succ.png" alt="install_nuget_succ" />



### 引入依赖

```
using Microsoft.Extensions.DependencyInjection;
```



### 实操

#### 单例模式

`services.AddSingleton`

```c#
using Microsoft.Extensions.DependencyInjection;

static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 20f
            };
            // 配置IOC
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IShippingCalculator, DoubleElevenShoppingCalculator>();
    
           // 从IOC提取服务
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var orderProcess = serviceProvider.GetService<IOrderProcessor>();

            var orderProcess2 = serviceProvider.GetService<IOrderProcessor>();
}
```

因为这里使用了`AddSingleton` ，所以即使调了两次`serviceProvider.GetService` ，还是只创建了了一个`OrderProcessor`实例。

`AddSingleton` 在整个生命周期运行的环境内，都有且只能创建一个实例。



#### 瞬时模式

`services.AddTransient`

```c#
services.AddTransient<IOrderProcessor, OrderProcessor>();
```

将上面的`AddSingleton` 改成`AddTransient` 后，再次执行，发现创建了两个`OrderProcessor`实例。



#### 作用域模式

`services.AddScoped`

```
services.AddScoped<IOrderProcessor, OrderProcessor>();
```

将上面的`AddSingleton` 改成`AddScoped` 后，再次执行，也只创建了一个`OrderProcessor`实例。

`AddScoped` 创建实例是根据作用域而定的，同一个服务在不同的作用域内将产生不同的实例。

举例`http`请求，每一次系统对外部请求的过程，就是一个作用域，新的作用域会产生新的服务实例。当`http` 请求处理完成后，这个实例就会被自动注销。直到再次处理`http` 请求，才会产生新实例。