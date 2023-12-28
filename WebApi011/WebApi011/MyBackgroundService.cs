
using System.Threading;

namespace WebApi011
{
    public class MyBackgroundService : BackgroundService
    {

        private readonly ILogger<MyHostedService> logger;
        public MyBackgroundService(ILogger<MyHostedService> logger)
            
        {
            this.logger = logger;
            logger.LogInformation(DateTime.Now.ToString() + "Before");
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation(DateTime.Now.ToString() + "start");


            return Task.Factory.StartNew(async () =>
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    logger.LogInformation(DateTime.Now.ToString() + "......");
                    try
                    {

                        await Task.Delay(2000, stoppingToken);
                    }
                    catch { }

                }
            }, stoppingToken);
        }
    }
}
