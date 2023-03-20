### c#不能多重继承

```c#
internal class Program
    {
        public class UIText : UIBase, IDragable, ICopyable
        {
            public void Drag() {
                // 继承IDragable
                return;
            }
            public void Copy() {
                // 继承ICopyable
                return;
            }
            public void Paste() {
                // 继承ICopyable
                return;
            }
        }

        public interface IDragable {
            void Drag();
        }
        public interface ICopyable {
            void Copy();
            void Paste();
        }
        public class UIBase
        {
            public int Size { get; set; }
            public int Position { get; set; }
            public void Draw()
            {
                Console.WriteLine("绘制UI");
            }
        }
}
```



注意这一行

```
public class UIText : UIBase, IDragable, ICopyable{}
```

这里`UIBase` 是一个类，`UIText` 不用实现就可以直接调用`UIBase` 中的方法，`UIText` 只能继承一个类。

但是`IDragable, ICopyable` 这两个是接口，`UIText` 可以继承多个接口，但是必须在类里面具体实现，接口带的这些方法。



### 泛型

应用场景 ——

定义多个信息通道，一个信息发布多个通道，比如同时发`emali`和`sms`

（1）定义接口

```c#
public interface INotification
    {
        public void Send(string message);
    }
```

（2）基于接口实现新的类

发`email`

```c#
public class MailService: INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"send email {message}");
        }
    }
```

发`sms`

```c#
public class SmsMessageService: INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"send SMS {message}");
        }
    }
```

（3）建立新的消息列表

```c#
public class OrderProcessor
    {
        //private readonly MailService _mailService;
        private readonly List<INotification> messageServices;

        public OrderProcessor()
        {
            //_mailService = new MailService();
            messageServices = new List<INotification>();
        }

        public void RegisterNotification(INotification notification)
        {
            // 往List里加INotification
            messageServices.Add(notification);
        }

        public void Process(Order order)
        {
            // 处理订单...处理发货...

            // 通知用户收货
            //_mailService.Send("订单已发货");
            // 遍历List中的INotification方法
            foreach(INotification n in messageServices)
            {
                n.Send("订单已发货");
            }
        }
    }
```

（4）调用以上创建的`private readonly List<INotification> messageServices;`

```c#
static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 30f
            };

            OrderProcessor orderProcessor = new OrderProcessor();

            INotification mailService = new MailService();
    		// 往List里加INotification
            orderProcessor.RegisterNotification(mailService);

            INotification smsService = new SmsMessageService();
    		// 往List里加INotification
            orderProcessor.RegisterNotification(smsService);

            orderProcessor.Process(order);

            Console.Read();
        }
```

