using System;
using System.Threading;
using System.Text;
using System.Globalization;
namespace Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var myDouble = "5,4";
            var turkishCulture = CultureInfo.GetCultureInfo("tr-TR");
            Console.WriteLine(Double.Parse(myDouble, CultureInfo.InvariantCulture));
            //54
            Console.WriteLine(Double.Parse(myDouble, turkishCulture));
            //5,4

            var description = "Description";

            Console.WriteLine(description.ToUpper() == "DESCRIPTION");
            //true
            Console.WriteLine(description.ToUpper().Equals("DESCRIPTION"));
            //true
            Console.WriteLine(Object.ReferenceEquals(description.ToUpper(), "DESCRIPTION"));
            //false

            Thread.CurrentThread.CurrentCulture = turkishCulture;

            Console.WriteLine(description.ToUpper() == "DESCRIPTION");
            //false DESCRİPTİON
            Console.WriteLine(description.ToUpperInvariant() == "DESCRIPTION");
            //true

            Console.WriteLine(description.Equals("DESCRIPTION", StringComparison.OrdinalIgnoreCase));
            //true

            var dt = "05/01/2012";
            Console.WriteLine(DateTime.Parse(dt).ToLongDateString());
            Console.WriteLine(DateTime.Parse(dt).ToString("dddd, MMMM dd yyyy"));
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(DateTime.Parse(dt).ToString("dddd, MMMM dd yyyy"));
            Console.WriteLine(DateTime.ParseExact(dt, "MM/dd/yyyy", turkishCulture).ToString("dddd, MMMM dd yyyy"));
        }
    }
}
