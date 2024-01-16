using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FIT_Api_Examples.Helper
{
    public static class Ekstenzije
    {
        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }
    }
}
