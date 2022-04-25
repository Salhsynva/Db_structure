using System;
using System.Collections.Generic;
using System.Text;

namespace DbStructure.Data.Exceptions
{
    class CommentCannotFoundException:Exception
    {
        public CommentCannotFoundException(string message):base(message)
        {

        }
    }
}
