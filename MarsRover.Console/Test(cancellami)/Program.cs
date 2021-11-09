﻿using MarsRover.Core;
using MarsRover.Reader;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using MarsRover.Writer;

namespace Test_cancellami_
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, config) =>
            {
                //config.AddJsonFile()
            })
            .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<RoverCore>();
                    services.AddSingleton<IAudit, ConsoleLogger>();
                    services.Decorate<IAudit, FileLogger>();
                    //services.Decorate<IAudit, SqlLogger>();
                    services.AddSingleton<IReader, CSVReader>();
                    services.AddHostedService<Worker>();
                });
    }

}