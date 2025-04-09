using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyMultiTaskService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly string _logFile = @"C:\Logs\WorkerLog.txt";

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            Directory.CreateDirectory(Path.GetDirectoryName(_logFile)!); // Ensure folder exists
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Log("✅ Worker starting up...");

            while (!stoppingToken.IsCancellationRequested)
            {
                string logMessage = $"🚀 Worker running at: {DateTimeOffset.Now}";
                Log(logMessage);
                await Task.Delay(3000, stoppingToken);
            }

            Log("🛑 Worker stopping...");
        }

        private void Log(string message)
        {
            File.AppendAllText(_logFile, $"{DateTimeOffset.Now:u} - {message}{Environment.NewLine}");
        }
    }
}
