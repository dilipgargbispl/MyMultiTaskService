namespace MyMultiTaskService
{
    public class OtpWorker : BackgroundService
    {
        private readonly ILogger<OtpWorker> _logger;
        public OtpWorker(ILogger<OtpWorker> logger) => _logger = logger;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OtpWorker started");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _logger.LogInformation("Sending OTP...");
                    // 🔧 Add your OTP logic here
                    await Task.Delay(3000, stoppingToken);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "OtpWorker failed");
                }
            }
        }
    }

}
