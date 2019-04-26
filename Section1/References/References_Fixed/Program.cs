using System;

namespace References_Fixed
{
    class Program
    {
        static void Main(string[] args)
        {
            var ninjas = new [] { "Itachi", "Kisame", "Naruto"};
            for(var i = 0; i < 3 ; i++)
            {
                AddGreeting(ref ninjas[i]);
            }
            foreach(var ninja in ninjas)
            {
                Console.WriteLine(ninja);
            }
        }
        static void AddGreeting(ref string ninja)
            =>  ninja = "Greetings " + ninja ;
    }
}
