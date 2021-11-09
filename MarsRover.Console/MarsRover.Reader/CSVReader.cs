using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.IO;


namespace MarsRover.Reader
{
    public partial class CSVReader : IReader
    {
        public IEnumerable<string> GetComandiFromCSV(string pathname)
        {
            var configCSV = new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture);
            configCSV.HasHeaderRecord = false;
            //configCSV.Delimiter = ";";
            using var streamreader = new StreamReader(pathname);
            using (var csvreader = new CsvReader(streamreader, configCSV))
            {
                //yield return csvreader.GetRecord<string>();
                
                csvreader.Context.RegisterClassMap<CSVRoverCommandsMapper>();

                foreach (var row in csvreader.GetRecords<Commands>())
                {
                    yield return row.Comandi;
                }
            }
        }
    }
}
