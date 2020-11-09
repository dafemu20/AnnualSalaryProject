using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Enum
{
    public class StringValueAttribute : Attribute
    {
        public string Value { get; private set; }

        public StringValueAttribute(string Value)
        {
            this.Value = Value;
        }
    }
}
