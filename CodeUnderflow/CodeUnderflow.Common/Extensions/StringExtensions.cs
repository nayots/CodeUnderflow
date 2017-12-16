using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeUnderflow.Common.Extensions
{
    public static class StringExtensions
    {
        public static ICollection<string> SplitAndFilterTagTitles(this string tagsString)
        {
            var titles = tagsString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Distinct(StringComparer.InvariantCultureIgnoreCase).Select(w => w.ToLower()).ToList();

            return titles;
        }
    }
}