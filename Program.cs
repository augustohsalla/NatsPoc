using CN.MPT.NATS_CLI_POC;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
            services.AddHostedService<Main>();
    })
    .Build();

await host.RunAsync();

