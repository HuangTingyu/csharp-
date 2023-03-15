using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 20f
            };
            IShippingCalculator doubleEleven = new DoubleElevenShoppingCalculator();
            IShippingCalculator common = new ShippingCalculator();
            var orderProcessor = new OrderProcessor(common);

            if (DateTime.Now == new DateTime(2023, 11, 11))
            {
                orderProcessor = new OrderProcessor(doubleEleven);
            }

            orderProcessor.Process(order);
        }
    }
}
