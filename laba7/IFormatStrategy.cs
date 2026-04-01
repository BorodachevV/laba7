using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public interface IFormatStrategy
    {
        string Format(string message, DateTime timestamp);
    }
}
