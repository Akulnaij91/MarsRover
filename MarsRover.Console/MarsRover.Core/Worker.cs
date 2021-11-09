using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.MapCore;

namespace MarsRover.Core
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;
        private readonly RoverCore _roverCore;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, RoverCore rovercore)
        {
            _logger = logger;
            _configuration = configuration;
            _roverCore = rovercore;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Parte all'inizio
            MapDrawer.MapInitializer();
            _roverCore.Engine();

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                //Consolelogga la mappa aggiornata
                //_roverCore.Engine();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
