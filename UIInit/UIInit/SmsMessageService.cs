using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIInit
{
    public class SmsMessageService: INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"send SMS {message}");
        }
    }
}
