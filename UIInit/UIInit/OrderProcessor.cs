using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIInit
{
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
            messageServices.Add(notification);
        }

        public void Process(Order order)
        {
            // 处理订单...处理发货...

            // 通知用户收货
            //_mailService.Send("订单已发货");
            foreach(INotification n in messageServices)
            {
                n.Send("订单已发货");
            }
        }
    }
}
