using System.Collections.Generic;

namespace MarsRover.Reader
{
    public interface IReader
    {
        IEnumerable<string> GetComandiFromCSV(string pathname);
    }
}
