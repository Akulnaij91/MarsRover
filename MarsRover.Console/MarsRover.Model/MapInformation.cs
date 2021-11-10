using System.Collections.Generic;

namespace MarsRover.Model
{
    public class MapInformation
    {
        public List<(int x, int z)> ElencoOstacoli;
        public readonly int LarghezzaMappa;
        public readonly int AltezzaMappa;

        public MapInformation(List<(int x, int z)> ostacoli, int larghezzaMap, int altezzaMap)
        {
            ElencoOstacoli = ostacoli;
            LarghezzaMappa = larghezzaMap;
            AltezzaMappa = altezzaMap;
        }
    }
}
