public class EmailWorker : BackgroundService
{
    private readonly ILogger<EmailWorker> _logger;
    private readonly string _logFile = @"C:\Logs\EmailLog.txt";

    public EmailWorker(ILogger<EmailWorker> logger)
    {
        _logger = logger;
        Directory.CreateDirectory(Path.GetDirectoryName(_logFile)!);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Log("📧 EmailWorker starting...");
        while (!stoppingToken.IsCancellationRequested)
        {
            Log("✉️ Sending email at: " + DateTimeOffset.Now);
            await Task.Delay(5000, stoppingToken);
        }
        Log("📪 EmailWorker stopping...");
    }

    private void Log(string message)
    {
        File.AppendAllText(_logFile, $"{DateTimeOffset.Now:u} - {message}{Environment.NewLine}");
    }
}
