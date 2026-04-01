using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class JsonFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp) =>
            $"{{\n  \"timestamp\": \"{timestamp:O}\",\n  \"message\": \"{message}\"\n}}";
    }
}
