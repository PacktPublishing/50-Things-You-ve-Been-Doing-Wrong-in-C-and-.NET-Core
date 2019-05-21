using System;
using System.Collections.Generic    ;

namespace Structs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            //boxing
            var o = (object) i;

            var s = 5;
            //casting
            var o2 = (object)s;
            int? j  = 5;
            Console.WriteLine(j.GetType().Name);

            var roe = new ReadOnlyEnumerator(new List<int>{1,2});
            roe.PrintTheFirstElement();
        }
    }

    //code sample taken from : https://blogs.msdn.microsoft.com/seteplia/2018/03/07/the-in-modifier-and-the-readonly-structs-in-c/
    internal class ReadOnlyEnumerator
    {
        private  List<int>.Enumerator _enumerator;
 
        public ReadOnlyEnumerator(List<int> list)
        {
            _enumerator = list.GetEnumerator();
        }
 
        public void PrintTheFirstElement()
        {
            _enumerator.MoveNext();
            Console.WriteLine(_enumerator.Current);
        }

    }
    
}
