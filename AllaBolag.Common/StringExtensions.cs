using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AllaBolag.Common
{
    public enum Position
    {
        Leading,
        Trailing,
        All
    }
    public static class StringExtensions
    {
        public static string Transform(this string source, Func<string, string> method)
        {
            var result = method(source);
            return result;
        }
    }
}
