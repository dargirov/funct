using Option;
using System;
using static Option.F;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var none = None;
            var some = Some<int>(5);

            Option<int> n = none;
            Option<int> s = some;
            Option<string> ss = None;
            Option<string> sss = Some("dfsd");
            Option<int> t = None;
            Option<string> tt = null;

            var t2 = t.Match(() => 6, x => x + 6);
            Console.WriteLine(t2);

            Console.WriteLine("sdfsd");
        }
    }
}
