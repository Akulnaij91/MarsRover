using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using MarsRover.MapCore;
using System;
using MarsRover.Model;
using MarsRover.Core;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace MarsRover.Service
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly RoverCore _roverCore;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, RoverCore rovercore, IConfiguration config)
        {
            _logger = logger;
            _roverCore = rovercore;
            _configuration = config;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var largMappaConfig = Convert.ToInt32(_configuration["larghezzaMappa"]);
            var altMappaConfig = Convert.ToInt32(_configuration["altezzaMappa"]);
            var initialDirConfig = Convert.ToChar(_configuration["initialDirectionRover"]);
            var initialXConfig = Convert.ToInt32(_configuration["initialXRover"]);
            var initialYConfig = Convert.ToInt32(_configuration["initialYRover"]);
            var executionTimer = Convert.ToInt32(_configuration["taskDelayTimer"]);

            string temp = _configuration["listaOstacoliStringa"];
            string[] strlist = temp.Split(";");

            var ostacoliConfig = new List<(int, int)>();
            foreach (var item in strlist)
            {
                string[] intlist = item.Split(",");
                (int, int) tupla = (Convert.ToInt32(intlist[0]), Convert.ToInt32(intlist[1]));
                ostacoliConfig.Add(tupla);
            }



            //List <(int, int)> ostacoliConfig = new()
            //{
            //    (1, 0),
            //    (5, 5),
            //    (1, 9),
            //    (7, 4),
            //    (6, 2)
            //};

            MapDrawer mapConfiguration = new(largMappaConfig, altMappaConfig, ostacoliConfig, initialDirConfig, initialXConfig, initialYConfig);

            //Inizializzo rover
            CoordinateRover coordinateIniziali = new(mapConfiguration._initialRoverX, mapConfiguration._initialRoverY, mapConfiguration._initialDirection);
            Rover myRover = new("Curiosity", coordinateIniziali);

            //Parte disegnando posizione all'inizio
            mapConfiguration.MapInitializer();

            //Inizializza info geografiche
            var tuplaOstacoli = mapConfiguration._arrayTupleOstacoli;
            var larghezzaMappa = mapConfiguration._larghezzaMappa;
            var altezzaMappa = mapConfiguration._altezzaMappa;
            MapInformation marsMap = new(tuplaOstacoli, larghezzaMappa, altezzaMappa);

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var commandExecution = _roverCore.Engine(myRover, mapConfiguration, marsMap);
                myRover.Coordinates = commandExecution.MyRover.Coordinates;
                myRover.MissionStatus = commandExecution.Status;
                _logger.LogInformation($"Mission Rover Status - {myRover.MissionStatus}");
                await Task.Delay(executionTimer, stoppingToken);

            }
        }
    }
}
