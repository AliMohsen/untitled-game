using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Entities.Exception
{
    public class InvalidEntityException : SystemException
    {
        public InvalidEntityException(String message)
            : base(message)
        {

        }

        public InvalidEntityException(String message, SystemException e) 
            : base(message, e)
        {
        }
    }
}
