using System;
using Microsoft.Extensions.DependencyInjection;

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
            // 配置IOC
            ServiceCollection services = new ServiceCollection();
            // singleton, 单例模式
            // scoped，作用域模式
            // transient，瞬时模式
            services.AddScoped<IOrderProcessor, OrderProcessor>();
            //services.AddSingleton<IOrderProcessor, OrderProcessor>();
            //services.AddTransient<IOrderProcessor, OrderProcessor>();
            services.AddScoped<IShippingCalculator, DoubleElevenShoppingCalculator>();

            // 从IOC提取服务
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var orderProcess = serviceProvider.GetService<IOrderProcessor>();

            orderProcess.Process(order);
            Console.Read();

            //IShippingCalculator doubleEleven = new DoubleElevenShoppingCalculator();
            //IShippingCalculator common = new ShippingCalculator();
            //var orderProcessor = new OrderProcessor(common);

            //if (DateTime.Now == new DateTime(2023, 11, 11))
            //{
            //    orderProcessor = new OrderProcessor(doubleEleven);
            //}

            //orderProcessor.Process(order);
        }
    }
}
