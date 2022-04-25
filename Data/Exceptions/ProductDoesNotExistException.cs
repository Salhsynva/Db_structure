using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class ProductDoesNotExistException:Exception
    {
        public ProductDoesNotExistException(string message):base(message)
        {

        }
    }
}
