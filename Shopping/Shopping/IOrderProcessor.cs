using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    public interface IOrderProcessor
    {
        public void Process(Order order);
    }
}
