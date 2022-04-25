using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class EmailAlreadyUsedException:Exception
    {
        public EmailAlreadyUsedException(string message):base(message)
        {

        }
    }
}
