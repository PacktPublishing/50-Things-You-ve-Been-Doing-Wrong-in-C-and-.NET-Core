using System;
using System.Collections.Generic;
using System.Linq;
namespace Find
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 4,3,2,1, 0};
            var three = list.Where(x => x == 3).FirstOrDefault();
            // same as above but shorter
            three = list.FirstOrDefault( x => x ==3);

            three = list.Find(x => x == 3);

            list.Sort();
            //only if your list is already sorted
            var indexOfThree = list.BinarySearch(3);

        }
    }
}
