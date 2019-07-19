using System;
using Microsoft.Extensions.DependencyInjection;

namespace LifeTimes
{
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
                var item = scope.ServiceProvider.GetService<Transaction>();
                item = scope.ServiceProvider.GetService<Transaction>();
            }

            using (var scope = globalProvider.CreateScope())
            {
                var item = scope.ServiceProvider.GetService<Transaction>();
                item = scope.ServiceProvider.GetService<Transaction>();
            }
        }
    }
}   
