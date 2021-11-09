using CsvHelper.Configuration;


namespace MarsRover.Reader
{
    public partial class CSVReader
    {
        internal class CSVRoverCommandsMapper : ClassMap<Commands>
        {
            public CSVRoverCommandsMapper()
            {
                Map(x => x.Comandi);
            }
        }
    }
}
