using System;
using System.Threading.Tasks;

namespace TaskSignature
{
    public class Customer 
    {

    }
    public interface ICustomerService
    {
       Task<Customer> GetCustomerDetails(int id);
    }
    public class CustomerService : ICustomerService
    {
         public Task<Customer> GetCustomerDetails(int id)
         {
             return Task.FromResult(new Customer());
         }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
