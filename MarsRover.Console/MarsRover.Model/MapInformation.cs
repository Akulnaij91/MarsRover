using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Model
{
    public class MapInformation
    {
        public List<(int x, int z)> ElencoOstacoli;
        public int LarghezzaMappa;
        public int AltezzaMappa;

        public MapInformation(List<(int x, int z)> ostacoli, int larghezzaMap, int altezzaMap)
        {
            ElencoOstacoli = ostacoli;
            LarghezzaMappa = larghezzaMap;
            AltezzaMappa = altezzaMap;
        }
    }
}
