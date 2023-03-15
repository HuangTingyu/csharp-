using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping
{
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
}
