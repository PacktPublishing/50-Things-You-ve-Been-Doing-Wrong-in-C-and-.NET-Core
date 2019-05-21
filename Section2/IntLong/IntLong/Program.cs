using System;
using System.Threading;
using System.Threading.Tasks;

namespace IntLong
{
    class Program
    {
        static int x;
        static long y;
        static void Main(string[] args)
        {
          
           Task.Run(DoWorkIntWrong);
           x = 1;

           //wrong
           y = 1;

           //wrong
           var z = y;

           //correct
           Interlocked.Exchange(ref y, 1);

           //correct
           var z2 = Interlocked.Read(ref y);

        }

        static void DoWorkIntWrong()
        {
            x++;
        }
       
        static void DoWorkInt1()
        {
            Interlocked.Add(ref x,1);
        }

        static void DoWorkLong()
        {
            Interlocked.Add(ref y,1);
        }
    }
}
