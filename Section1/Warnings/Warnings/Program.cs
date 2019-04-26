using System;

namespace Warnings
{
    static class Program
    {
        static string firstName;
        static string lastName;
        static void Main(string[] args)
        {
            firstName = Console.ReadLine();
            Console.WriteLine("Your name is " + firstName);
        }
    }
}
