using System;

namespace Exceptions
{
    class Product
    {
        public string Name { get; set;}
        public decimal Price { get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Enter product name:");
                var productName = Console.ReadLine();
                Console.WriteLine("Enter desired price:");
                var price = decimal.Parse(Console.ReadLine());
                var prod = new Product(){ Name = productName, Price = price};
                DoShopping(prod);
            }
        }

        static void DoShopping(Product p)
        {
            CalculateTax(p);
        }

        static void CalculateTax(Product p)
        {
            try{
            var previousPrice = p.Price;
            p.Price += 1M;
            var taxIncrease = (p.Price -  previousPrice ) / previousPrice;
            Console.WriteLine($"Price increase {taxIncrease.ToString("P")}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
