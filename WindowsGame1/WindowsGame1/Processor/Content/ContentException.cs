﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGameOfForever.Processor.Content
{
    public class ContentException : SystemException
    {
        public ContentException(String message)
            : base(message) { }
    }
}
