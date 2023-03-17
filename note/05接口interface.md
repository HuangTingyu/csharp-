### 添加interface

<img src="..\image\create_interface0.png" alt="create_interface0" style="zoom:30%;" />



![create_interface](D:\00工作笔记\csharp_note\image\create_interface.png)



### 实现

`IShippingCalculator.cs`

```c#
public interface IShippingCalculator
    {
        float CalculateShipping(Order order);
    }
```

结合class使用

`DoubleElevenShoppingCalculator.cs`

```c#
public class DoubleElevenShoppingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            return 0;
        }
    }
```

`ShippingCalculator.cs`

```c#
public class ShippingCalculator : IShippingCalculator
    {
        public float CalculateShipping(Order order)
        {
            if (order.TotalPrice < 30f)
                return order.TotalPrice * 0.1f;
            return 0;
        }
    }
```



`OrderProcessor.cs`

```c#
public class OrderProcessor
    {
        private readonly IShippingCalculator _shippingCalculator;

        public OrderProcessor(IShippingCalculator shippingCalculator)
        {
            _shippingCalculator = shippingCalculator;
        }

        public void Process(Order order)
        {
            if (order.IsShipped)
                throw new InvalidOperationException("订单已发货");

            DateTime doubleEleven = new DateTime(2022, 11, 11);

            order.Shipment = new Shipment
            {
                Cost = _shippingCalculator.CalculateShipping(order),

                ShippingDate = DateTime.Today.AddDays(1)
            };
            Console.WriteLine($"订单运费{order.Shipment.Cost}元完成，已发货");
            Console.WriteLine($"订单#{order.Id}完成，已发货");
        }
    }
```



### 调用

```c#
var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 20f
            };
            IShippingCalculator doubleEleven = new DoubleElevenShoppingCalculator();
            IShippingCalculator common = new ShippingCalculator();
			// new的时候把interface传进去
            var orderProcessor = new OrderProcessor(common);

            if (DateTime.Now == new DateTime(2023, 11, 11))
            {
                // new的时候把interface传进去
                orderProcessor = new OrderProcessor(doubleEleven);
            }

            orderProcessor.Process(order);
```



### 测试

创建测试项目

![test_class0](..\image\test_class0.png)



项目命名注意，`要测试的项目名+ .UnitTests` ，例如 `Shopping.UnitTests`

![test_class1](..\image\test_class1.png)



右键“解决方案”，添加要测试的项目，选择`.csproj` 文件

<img src="..\image\test_class2.png" alt="test_class2" style="zoom:30%;" />



右键`Shopping.UnitTests`添加项目引用

<img src="..\image\test_class3.png" alt="test_class3" style="zoom:33%;" />



### 测试代码

`OrderProcessorTest.cs`

```c#
public void Process_OrderUnshipped_SetShippment()
        {
            OrderProcessor orderProcessor = new OrderProcessor(new FakeShippingCalculator());

            Order order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f
            };
            orderProcessor.Process(order);
            Assert.AreEqual(order.Shipment.Cost, 5); 
            Assert.IsTrue(order.IsShipped);
        }
```

关键`Assert`，

```c#
Assert.AreEqual(order.Shipment.Cost, 5); // 输出的order.Shipment.Cost是否等于5
```

```c#
Assert.IsTrue(order.IsShipped); //order.IsShipped是否为false
```



点击Tab“测试”，"运行所有测试"

<img src="..\image\exe_test.png" alt="exe_test" style="zoom:30%;" />



运行失败debug，`Assert.IsTrue(order.IsShipped);` 表示这一行代码运行失败。

```
Assert.IsTrue failed 
```

![exe_test_fail](..\image\exe_test_fail.png)



测试捕捉 `exception`

主要语句，在测试方法上方添加

```c#
[ExpectedException(typeof(InvalidOperationException))]
```



```c#
[TestMethod]
[ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsshipped_ThrowException()
        {
            OrderProcessor orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            Order order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f,
                IsShipped = true
            };
            orderProcessor.Process(order);
        }
```

