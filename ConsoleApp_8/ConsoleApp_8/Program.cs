using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            var str = Console.ReadLine();
            var pattern = "(?<hour>0[0-9]|1[0-9]|2[0-3]):(?<min>[0-5][0-9]):(?<sec>[0-5][0-9])";
            str = Regex.Replace(str, pattern, (m) =>
            {
                var ts = TimeSpan.Parse(m.Value);
                if (ts.Seconds >= 30)
                    ts = ts.Add(new TimeSpan(0, 1, 0));

                return ts.ToString(@"hh\:mm");
            });

            Console.Write($"Измененная строка: {str}");
            Console.ReadLine();
        }
    }
}
