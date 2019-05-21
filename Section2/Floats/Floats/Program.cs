using System;

namespace Floats
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = 0f;
            var d = 0d;
            var money = 0M;
            Console.WriteLine(0.3 * 3.0 + 0.1 == 1.0);
            Console.WriteLine(0.3M * 3.0M + 0.1M == 1.0M);
        }
    }
}
