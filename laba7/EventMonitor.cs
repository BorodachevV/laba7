using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public delegate void MetricEventHandler(MetricEventArgs e);
    public class EventMonitor
    {
        public event MetricEventHandler? OnMetricExceeded;

        public void CheckMetric(string metricName, double value, double threshold)
        {
            Console.WriteLine($"\n[Monitor]: Checking {metricName} ({value} vs {threshold})");

            if (value > threshold)
            {
                var eventData = new MetricData(metricName, value, threshold, DateTime.Now);
                OnMetricExceeded?.Invoke(new MetricEventArgs(metricName + "_Exceeded", eventData));
            }
            else
            {
                Console.WriteLine($"[Monitor]: {metricName} is within normal limits.");
            }
        }
    }
}
