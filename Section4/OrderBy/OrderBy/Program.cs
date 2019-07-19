using System;
using System.Collections.Generic;
using System.Linq;
namespace OrderBy
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 4,3,2,1};
            var orderedList = list.OrderBy( x=> x).ToList();
            list.Sort();
        }
    }
}
