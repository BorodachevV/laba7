using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class TextFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp) =>
            $"[{timestamp:yyyy-MM-dd HH:mm:ss}] PLAIN TEXT: {message}";
    }
}
