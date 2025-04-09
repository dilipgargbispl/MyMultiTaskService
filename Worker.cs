﻿namespace MyMultiTaskService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("✅ Worker starting up...");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("🚀 Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(3000, stoppingToken);
            }

            _logger.LogInformation("🛑 Worker stopping...");
        }
    }

}
