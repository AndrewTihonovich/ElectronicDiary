using Microsoft.Extensions.Logging;
using System;

namespace ElectronicDiary.DAL.Logging
{
    class DiaryDbContextLogger : ILogger, IDisposable
    {
        private bool _disposedValue;

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Database logs: {formatter(state, exception)}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {

                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
