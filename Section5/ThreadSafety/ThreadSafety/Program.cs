using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ThreadSafety
{

    class Program
    {
        static object locker = new object();
        static List<int> l = new List<int>();
        static void Main(string[] args)
        {

            Task.Run(Loop);
            Task.Run(Loop);
            Console.ReadKey();
        }
        static void Loop()
        {
            try
            {
                while (true)
                {
                    lock (locker)
                    {
                        l.Add(1);
                        l.RemoveAt(0);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
