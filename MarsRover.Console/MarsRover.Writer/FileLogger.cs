using MarsRover.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Writer
{
    public class FileLogger : AuditDecorator
    {
        private readonly IConfiguration _configuration;
        public FileLogger(IAudit logger, IConfiguration configuration) : base(logger)
        {
            _configuration = configuration;
        }
        public override void Log(Rover myRover)
        {
            base.Log(myRover);
            var lastPosition = $"{myRover.Coordinates.CoordinataX},{myRover.Coordinates.CoordinataY},{myRover.Coordinates.Direzione};";
            File.WriteAllText(_configuration["pathnameOutput"], lastPosition);
        }
    }
}
