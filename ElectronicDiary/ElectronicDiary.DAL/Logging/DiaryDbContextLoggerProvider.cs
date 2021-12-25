using Microsoft.Extensions.Logging;

namespace ElectronicDiary.DAL.Logging
{
    public class DiaryDbContextLoggerProvider : ILoggerProvider
    {
        private readonly DiaryDbContextLogger _logger;

        public DiaryDbContextLoggerProvider()
        {
            _logger = new DiaryDbContextLogger();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _logger;
        }

        public void Dispose()
        {
            _logger.Dispose();
        }
    }
}
