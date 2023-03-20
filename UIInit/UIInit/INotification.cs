using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIInit
{
    public interface INotification
    {
        public void Send(string message);
    }
}
