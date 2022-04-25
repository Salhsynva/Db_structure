using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class PriceCannotBeNegativeException:Exception
    {
        public PriceCannotBeNegativeException(string message):base(message)
        {

        }
    }
}
