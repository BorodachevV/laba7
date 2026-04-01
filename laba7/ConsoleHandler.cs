using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class ConsoleHandler : EventHandlerBase
    {
        public ConsoleHandler(IFormatStrategy strategy) : base(strategy) { }

        protected override void SendMessage(string message)
        {
            Console.WriteLine(">>> НАЧАЛО ВЫВОДА В КОНСОЛЬ <<<");
            Console.WriteLine(message);
            Console.WriteLine(">>> КОНЕЦ ВЫВОДА В КОНСОЛЬ <<<");
        }

        protected override void LogResult()
        {
            Console.WriteLine("[System Log]: Уведомление успешно отправлено в консоль.");
        }
    }
}
