    using System;
    using System.Text;
using CN.MPT.NATS_CLI_POC;
    using NATS.Client;

    public class Main : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Main(ILogger<Worker> logger)
        {
            _logger = logger;
        }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}