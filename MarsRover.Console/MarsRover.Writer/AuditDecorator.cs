using MarsRover.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Writer
{
    public abstract class AuditDecorator : Audit
    {
        private readonly IAudit _audit;
        public AuditDecorator(IAudit aud)
        {
            _audit = aud;
        }
        public override void Log(Rover myRover)
        {
            _audit.Log(myRover);
        }
    }
}
