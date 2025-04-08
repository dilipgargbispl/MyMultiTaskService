using MyMultiTaskService;

var builder = Host.CreateApplicationBuilder(args);

// Register multiple independent workers
builder.Services.AddHostedService<Worker>();       // Optional monitoring or base logic
builder.Services.AddHostedService<EmailWorker>();  // Email sender
builder.Services.AddHostedService<OtpWorker>();    // OTP sender
// Add more services here...

var host = builder.Build();
host.Run();
