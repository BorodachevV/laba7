namespace laba7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инициализация системы мониторинга...\n");

            
            EventMonitor monitor = new EventMonitor();

            
            var consoleTextHandler = new ConsoleHandler(new TextFormatStrategy());
            var consoleJsonHandler = new ConsoleHandler(new JsonFormatStrategy());

            string logFilePath = "alerts_log.txt";
            var fileHtmlHandler = new FileHandler(new HtmlFormatStrategy(), logFilePath);

            
            if (File.Exists(logFilePath)) File.Delete(logFilePath);

            
            monitor.OnMetricExceeded += consoleTextHandler.ProcessEvent;
            monitor.OnMetricExceeded += fileHtmlHandler.ProcessEvent;

            
            monitor.CheckMetric("CPU_Usage", 45.0, 90.0);

         
            monitor.CheckMetric("Memory_Usage", 95.5, 85.0);

          
            Console.WriteLine("\n[System]: Смена стратегии форматирования для консольного обработчика на JSON...");
            consoleTextHandler.SetStrategy(new JsonFormatStrategy());

           
            monitor.CheckMetric("Network_Traffic", 1024.0, 500.0);

            Console.WriteLine("\nРабота системы завершена.");
        }
    }
}
