using System;
using System.Net.Http;

namespace HttpRedir
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var res = client
                .GetAsync("https://httpbin.org/redirect-to?url=https://google.com")
                .Result.Content.ReadAsStringAsync()
                .Result;
            Console.WriteLine(res);

        }
    }
}
