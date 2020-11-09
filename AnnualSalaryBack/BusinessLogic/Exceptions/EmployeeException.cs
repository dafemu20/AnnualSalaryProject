using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class EmployeeException : Exception
    {
        public EmployeeException()
        {
        }

        public EmployeeException(string message) : base(message)
        {
        }

        public EmployeeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
