using MarsRover.MapCore;
using MarsRover.Model;

namespace MarsRover.Writer
{
    public abstract class AuditDecorator : Audit
    {
        private readonly IAudit _audit;
        public AuditDecorator(IAudit aud)
        {
            _audit = aud;
        }
        public override void Log(Rover myRover, MapDrawer map)
        {
            _audit.Log(myRover, map);
        }
    }
}
