using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class NotInEmailFormatException:Exception
    {
        public NotInEmailFormatException(string message):base(message)
        {

        }
    }
}
