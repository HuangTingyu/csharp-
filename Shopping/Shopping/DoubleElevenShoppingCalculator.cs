using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
    public class DoubleElevenShoppingCalculator : IShippingCalculator
    {
        public DoubleElevenShoppingCalculator()
        {
            Console.WriteLine("DoubleElevenShoppingCalculator被创建了");
        }
        public float CalculateShipping(Order order)
        {
            return 0;
        }
    }
}
