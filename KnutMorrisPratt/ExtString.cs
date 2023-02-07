using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnutMorrisPratt
{
    static class ExtString
    {
        public static string Left(this string str, int x)
        {
            return str.Substring(0, x);
        }
        public static string Right(this string str, int x)
        {
            return str.Substring(str.Length - x);
        }
    }
}
