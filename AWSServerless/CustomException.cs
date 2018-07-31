using System;
using System.Collections.Generic;
using System.Text;

namespace AWSServerless
{
    class CustomException: Exception
    {
        public CustomException(string message): base(message)
        {

        }
    }
}
