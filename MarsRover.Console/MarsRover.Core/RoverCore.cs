using MarsRover.MapCore;
using MarsRover.Model;
using MarsRover.Reader;
using MarsRover.Writer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace MarsRover.Core
{
    public class RoverCore
    {
        private readonly IConfiguration _configuration;
        private readonly IAudit _fileLogger;
        private readonly ILogger<RoverCore> _logger;
        private readonly IReader _reader;
        public RoverCore(IConfiguration configuration, IReader reader, IAudit file, ILogger<RoverCore> logger)
        {
            _configuration = configuration;
            _reader = reader;
            _fileLogger = file;
            _logger = logger;
        }
        public MissionStatus Engine(Rover myRover, MapDrawer mapdrawer, MapInformation marsMap)
        {
            //Comandi
            var listaComandi = _reader.GetComandiFromCSV(_configuration["pathnameInput"]).ToList();

            if (listaComandi.Count<=0)
            {
                _logger.LogInformation($"MarsTime - {DateTime.Now} - Rover: {GeneratoreFrasiDiAbbandono(myRover)}");
                return new MissionStatus("Awaiting...", myRover);
            } else
            {
                //Prendi singoli comandi dal file
                char[] elencoComandi = listaComandi[0].ToUpper().ToCharArray();
                //Cicla i comandi e ottieni una coordinata

                for (var i = 0; i < elencoComandi.Length; i++)
                {
                    //Analizza ultima posizione nota e ottieni nuova coordinata
                    var nuovaPosizione = ChainCommandAnalysis.NewCoordinates(elencoComandi[i], myRover, marsMap);
                    myRover.Coordinates.CoordinataX = nuovaPosizione.X;
                    myRover.Coordinates.CoordinataY = nuovaPosizione.Y;
                    myRover.Coordinates.Direzione = nuovaPosizione.Oriented;
                    myRover.Coordinates.Stuck = nuovaPosizione.Stuck;

                    //Console logga coordinata + scrivi su stesso file la coordinata
                    _fileLogger.Log(myRover, mapdrawer);
                }
                //Svuoto file letto
                File.WriteAllText(_configuration["pathnameInput"], "");

                return new MissionStatus("Commands executed", myRover);
            }
        }

        public string GeneratoreFrasiDiAbbandono(Rover myRover)
        {
            string[] frasi = new string[] {
                "Dai amici scherzavo, portatemi a casa",
                "Mi è sembrato di vedere qualcosa! o_O",
                "Beep-boop-beep. Scherzo, so parlare",
                "Da quassù siete così...piccoli",
                "Houston, abbiamo un problema, mi sto annoiando",
                "Ma pensate di lasciarmi parcheggiato quassù a far nulla?",
                "<MODALITA' SARCASMO: ON> Wow! Sassi!",
                "Sto lavorando meno di un impiegato alle poste",
                "Un sacco di geni laggiù e ancora nessuno che mi ha creato un'amica",
                "Toh! La tesla di Elon Musk!"
            };

            Random rnd = new Random();
            return $"Rover {myRover.Name} " +
                $"- Last position {myRover.Coordinates.CoordinataX},{myRover.Coordinates.CoordinataY},{myRover.Coordinates.Direzione} " +
                $"{Environment.NewLine}{frasi[rnd.Next(0, frasi.Length)]}";
        }

    }
}
