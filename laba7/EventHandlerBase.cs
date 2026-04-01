using System;
using System.Collections.Generic;
using System.Text;

namespace laba7
{
    public abstract class EventHandlerBase
    {
        protected IFormatStrategy _formatStrategy;

        protected EventHandlerBase(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void SetStrategy(IFormatStrategy strategy)
        {
            _formatStrategy = strategy;
        }

        public void ProcessEvent(MetricEventArgs e)
        {
            string rawMessage = $"Внимание! Событие: {e.EventType} | Детали: {e.Data}";
            var formattedMessage = FormatMessage(rawMessage, e.Data.Timestamp);

            SendMessage(formattedMessage);
            LogResult();
        }

        
        protected virtual string FormatMessage(string rawMessage, DateTime timestamp)
        {
            return _formatStrategy.Format(rawMessage, timestamp);
        }

        
        protected abstract void SendMessage(string message);

        
        protected virtual void LogResult()
        {
            // По умолчанию ничего не делает, подклассы могут переопределить
        }
    }
}
