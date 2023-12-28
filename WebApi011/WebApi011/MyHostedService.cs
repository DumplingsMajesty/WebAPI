
using Microsoft.Extensions.Logging;

namespace WebApi011
{
    public class MyHostedService : IHostedService
    {

        private readonly ILogger<MyHostedService> logger;

        public MyHostedService(ILogger<MyHostedService> logger)
        {

            this.logger = logger;
            logger.LogInformation(DateTime.Now.ToString() + "Before");

        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation(DateTime.Now.ToString() + "start");


            return Task.Factory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    logger.LogInformation(DateTime.Now.ToString() + "......");
                    try
                    {

                        await Task.Delay(2000, cancellationToken);
                    }
                    catch { }

                }
            }, cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {

            logger.LogInformation(DateTime.Now.ToString() + "stop");
            return Task.CompletedTask;
        }
    }
}
