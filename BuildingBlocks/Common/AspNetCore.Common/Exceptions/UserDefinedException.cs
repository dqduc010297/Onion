using AspNetCore.Common.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Exceptions
{
    public class UserDefinedException : Exception
    {
        public ExceptionMessage UserDefinedMessage;
        public UserDefinedException(ExceptionMessage message) : base(message.Message)
        {
            UserDefinedMessage = message;
        }
        public UserDefinedException(string message)
        {
            UserDefinedMessage = new ExceptionMessage(message);
        }
    }
}
