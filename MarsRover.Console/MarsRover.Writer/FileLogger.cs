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
        public override void Log(int x, int y, char direction, bool stuck)
        {
            base.Log(x,y,direction, stuck);
            var lastPosition = $"{x},{y},{direction};";
            File.WriteAllText(_configuration["pathnameOutput"], lastPosition);
        }
    }
}
