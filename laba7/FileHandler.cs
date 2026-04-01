using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public class FileHandler : EventHandlerBase
    {
        private readonly string _filePath;

        public FileHandler(IFormatStrategy strategy, string filePath) : base(strategy)
        {
            _filePath = filePath;
        }

        protected override void SendMessage(string message)
        {
            File.AppendAllText(_filePath, message + Environment.NewLine + new string('-', 40) + Environment.NewLine);
        }

        protected override void LogResult()
        {
            Console.WriteLine($"[System Log]: Уведомление успешно сохранено в файл ({_filePath}).");
        }
    }
}
