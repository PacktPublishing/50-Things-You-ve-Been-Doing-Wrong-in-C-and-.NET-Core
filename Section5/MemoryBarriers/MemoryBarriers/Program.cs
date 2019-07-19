using System;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryBarriers
{
     class Program
    {
        static volatile int x, y, a, b;
        static void Main()
        {
            while (true)
            {
                var t1 = Task.Run(Test1);
                var t2 = Task.Run(Test2);
                Task.WaitAll(t1, t2);
                if (a == 0 && b == 0)
                {
                    Console.WriteLine("{0}, {1}", a, b);
                }
                x = y = a = b = 0;
            }
        }

        static void Test1()
        {
            x = 1;
            Interlocked.MemoryBarrierProcessWide();
            a = y;
        }

        static void Test2()
        {
            y = 1;
            b = x;
        }
    }
}