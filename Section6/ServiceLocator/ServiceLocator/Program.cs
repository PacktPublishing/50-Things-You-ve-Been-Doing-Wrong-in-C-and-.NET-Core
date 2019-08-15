using System;
using Microsoft.Extensions.DependencyInjection;

namespace ServiceLocator
{
    class OrderServiceWrong 
    {
        Transaction transaction;
        public OrderServiceWrong(IServiceProvider serviceProvider)
        {
            this.transaction = serviceProvider.GetService<Transaction>();
        }
    }
    class Transaction : IDisposable
    {
        public Transaction()
        {
            Console.WriteLine("Begin tran");
        }
        public void Dispose()
        {
            Console.WriteLine("End tran");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<Transaction>();

            var globalProvider = services.BuildServiceProvider();
            using (var scope = globalProvider.CreateScope())
            {
                var orderService = new OrderServiceWrong(scope.ServiceProvider);
            }
        }
    }
}
