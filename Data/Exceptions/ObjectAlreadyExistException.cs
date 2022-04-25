using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class ObjectAlreadyExistException:Exception
    {
        public ObjectAlreadyExistException(string message):base(message)
        {

        }
    }
}
