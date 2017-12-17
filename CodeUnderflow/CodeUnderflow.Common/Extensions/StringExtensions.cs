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

        public static ICollection<int> GetCookiesQuestionIds(this string cookieString)
        {
            var data = cookieString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            ICollection<int> ids = new List<int>();

            foreach (var entry in data)
            {
                if (int.TryParse(entry, out int id))
                {
                    ids.Add(id);
                }
            }

            return ids;
        }
    }
}