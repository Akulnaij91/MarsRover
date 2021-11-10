using MarsRover.MapCore;
using MarsRover.Model;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MarsRover.Writer
{
    public class FileLogger : AuditDecorator
    {
        private readonly IConfiguration _configuration;
        public FileLogger(IAudit logger, IConfiguration configuration) : base(logger)
        {
            _configuration = configuration;
        }
        public override void Log(Rover myRover, MapDrawer map)
        {
            base.Log(myRover, map);
            var lastPosition = $"{myRover.Coordinates.CoordinataX},{myRover.Coordinates.CoordinataY},{myRover.Coordinates.Direzione};";
            File.WriteAllText(_configuration["pathnameOutput"], lastPosition);
        }
    }
}
