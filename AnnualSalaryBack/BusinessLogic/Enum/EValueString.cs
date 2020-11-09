using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BusinessLogic.Enum
{
    public static class EValueString
    {
        public static string GetStringValue<T>(this T value) where T : IConvertible
        {
            string stringValue = value.ToString();
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attrs = fieldInfo.
                GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            if (attrs.Length > 0)
            {
                stringValue = attrs[0].Value;
            }
            return stringValue;
        }
    }
}
