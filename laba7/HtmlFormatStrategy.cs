using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class HtmlFormatStrategy : IFormatStrategy
    {
        public string Format(string message, DateTime timestamp) =>
            $"<div class='alert'>\n  <span class='time'>{timestamp:yyyy-MM-dd HH:mm:ss}</span>\n  <span class='msg'>{message}</span>\n</div>";
    }
}
