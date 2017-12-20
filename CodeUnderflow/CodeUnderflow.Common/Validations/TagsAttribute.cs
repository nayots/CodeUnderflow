using CodeUnderflow.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

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