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
            //Inizializzo rover
            CoordinateRover coordinateIniziali = new CoordinateRover(MapDrawer._initialRoverX, MapDrawer._initialRoverY, MapDrawer._initialDirection, false);
            Rover myRover = new Rover ("Curiosity", coordinateIniziali);

            //Parte disegnando posizione all'inizio
            MapDrawer.MapInitializer();

            //Inizializza info geografiche
            var tuplaOstacoli = MapDrawer._arrayTupleOstacoli;
            var larghezzaMappa = MapDrawer._larghezzaMappa;
            var altezzaMappa = MapDrawer._altezzaMappa;
            MapInformation marsMap = new MapInformation(tuplaOstacoli, larghezzaMappa, altezzaMappa);

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var commandExecution = _roverCore.Engine(myRover, marsMap);
                myRover.Coordinates = commandExecution.myRover.Coordinates;
                myRover.MissionStatus = commandExecution.Status;
                Console.WriteLine($"Mission Rover Status - {myRover.MissionStatus}");
                await Task.Delay(30000, stoppingToken);

            }
        }
    }
}
