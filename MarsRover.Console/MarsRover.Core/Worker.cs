using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.MapCore;
using System;
using MarsRover.Model;

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
            Rover myRover = _roverCore.Engine();
            Console.WriteLine($"MarsTime - {DateTime.Now} - Rover: {_roverCore.GeneratoreFrasiDiAbbandono(myRover)}");


            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
