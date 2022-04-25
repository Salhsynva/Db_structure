using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class UserDoesNotExistException:Exception
    {
        public UserDoesNotExistException(string message):base(message)
        {
               
        }
    }
}
