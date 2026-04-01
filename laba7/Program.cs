namespace laba7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация системы мониторинга...\n");

            // 1. Создаем субъекта (Издателя)
            EventMonitor monitor = new EventMonitor();

            // 2. Создаем подписчиков с разными стратегиями
            var consoleTextHandler = new ConsoleHandler(new TextFormatStrategy());
            var consoleJsonHandler = new ConsoleHandler(new JsonFormatStrategy());

            string logFilePath = "alerts_log.txt";
            var fileHtmlHandler = new FileHandler(new HtmlFormatStrategy(), logFilePath);

            // Очистка тестового файла перед запуском
            if (File.Exists(logFilePath)) File.Delete(logFilePath);

            // 3. Подписываем обработчики на событие монитора (Связываем Наблюдателя)
            // При возникновении события будет вызываться шаблонный метод ProcessEvent
            monitor.OnMetricExceeded += consoleTextHandler.ProcessEvent;
            monitor.OnMetricExceeded += fileHtmlHandler.ProcessEvent;

            // 4. Симулируем проверку метрик
            // Нормальная ситуация (не вызовет событие)
            monitor.CheckMetric("CPU_Usage", 45.0, 90.0);

            // Критическая ситуация (вызовет событие)
            monitor.CheckMetric("Memory_Usage", 95.5, 85.0);

            // 5. Динамическая смена стратегии (демонстрация гибкости)
            Console.WriteLine("\n[System]: Смена стратегии форматирования для консольного обработчика на JSON...");
            consoleTextHandler.SetStrategy(new JsonFormatStrategy());

            // Еще одна критическая ситуация
            monitor.CheckMetric("Network_Traffic", 1024.0, 500.0);

            Console.WriteLine("\nРабота системы завершена.");
        }
    }
}
