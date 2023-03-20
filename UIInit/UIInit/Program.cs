using System;

namespace UIInit
{
    internal class Program
    {
        public class UIText : UIBase, IDragable, ICopyable
        {
            public void Drag() {
                return;
            }
            public void Copy() {
                return;
            }
            public void Paste() {
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
            orderProcessor.RegisterNotification(mailService);

            INotification smsService = new SmsMessageService();
            orderProcessor.RegisterNotification(smsService);

            orderProcessor.Process(order);

            Console.Read();
        }
    }
}
