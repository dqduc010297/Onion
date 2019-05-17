using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Common.Messages
{
    public class ExceptionMessage
    {
        public string Message { set; get; }
        public List<ExceptionMessage> Details { set; get; }
        public ExceptionMessage()
        {

        }
        public ExceptionMessage(string message)
        {
            Message = message;
        }
    }
}
