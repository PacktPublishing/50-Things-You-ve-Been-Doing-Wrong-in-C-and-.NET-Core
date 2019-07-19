using System;
using System.Linq;
using System.Collections.Generic;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 4,3,2,1, 0};
            var three = list.Where(x => x == 3).FirstOrDefault();
            three = list.AsQueryable().Where(x => x == 3).FirstOrDefault();
        }
    }
}
