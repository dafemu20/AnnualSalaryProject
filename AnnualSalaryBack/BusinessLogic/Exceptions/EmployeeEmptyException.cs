using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class EmployeeEmptyException : Exception
    {
        public EmployeeEmptyException()
        {
        }

        public EmployeeEmptyException(string message) : base(message)
        {
        }

        public EmployeeEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
