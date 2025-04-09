using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyMultiTaskService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService() // 👈 enable running as a Windows Service
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();       // Optional core logic
        services.AddHostedService<EmailWorker>();  // Email sender
        services.AddHostedService<OtpWorker>();    // OTP sender
        // Add more services here if needed
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();     // For console testing
        logging.AddEventLog();    // For Windows Event Viewer logs
    })
    .Build();

await host.RunAsync();
