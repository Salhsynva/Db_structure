using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class UsernameCannotBeRepeatedException:Exception
    {
        public UsernameCannotBeRepeatedException(string message):base(message)
        {

        }
    }
}
