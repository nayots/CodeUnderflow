using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeUnderflow.Common.Extensions;

namespace CodeUnderflow.Common.Validations
{
    [AttributeUsageAttribute(AttributeTargets.Property, AllowMultiple = true)]
    public class TagsAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return false;
            }

            string tags = value as string;

            var tagNames = tags.SplitAndFilterTagTitles();

            if (tagNames.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
