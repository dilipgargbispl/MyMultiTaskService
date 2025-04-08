namespace MyMultiTaskService
{
    public class EmailWorker : BackgroundService
    {
        private readonly ILogger<EmailWorker> _logger;
        public EmailWorker(ILogger<EmailWorker> logger) => _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("EmailWorker started");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Sending email...");
                    // 🔧 Add your actual email logic here
                    await Task.Delay(5000, stoppingToken); // Simulate delay
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "EmailWorker failed");
                }
            }
        }
    }

}
