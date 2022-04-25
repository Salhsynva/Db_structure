using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class CountCannotBeNegativeException:Exception
    {
        public CountCannotBeNegativeException(string message):base(message)
        {

        }
    }
}
