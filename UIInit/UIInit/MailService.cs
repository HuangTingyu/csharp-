using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIInit
{
    public class MailService: INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"send email {message}");
        }
    }
}
