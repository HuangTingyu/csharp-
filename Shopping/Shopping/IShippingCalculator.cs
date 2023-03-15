using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    public interface IShippingCalculator
    {
        float CalculateShipping(Order order);
    }
}
