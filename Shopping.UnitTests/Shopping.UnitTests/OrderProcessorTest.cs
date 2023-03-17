using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping;
using System;

namespace Shopping.UnitTests
{
    [TestClass]
    public class OrderProcessorTest
    {
        [TestMethod]
        public void Process_OrderUnshipped_SetShippment()
        {
            OrderProcessor orderProcessor = new OrderProcessor(new FakeShippingCalculator());

            Order order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f
            };
            orderProcessor.Process(order);
            Assert.AreEqual(order.Shipment.Cost, 5);
            Assert.IsTrue(order.IsShipped);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Process_OrderIsshipped_ThrowException()
        {
            OrderProcessor orderProcessor = new OrderProcessor(new FakeShippingCalculator());
            Order order = new Order
            {
                Id = 123,
                DatePlaced = DateTime.Now,
                TotalPrice = 100f,
                IsShipped = true
            };
            orderProcessor.Process(order);
        }
    }
}
