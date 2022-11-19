using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Attributes;

    public static class Validator 
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties()
                .Where(p => p.GetCustomAttributes(typeof(MyValidationAttribute)).Any()).ToArray();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(obj);
                MyValidationAttribute attribute = property.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.IsValid(value);

                if (!isValid) return false;
            }

            return true;
        }
    }
}
