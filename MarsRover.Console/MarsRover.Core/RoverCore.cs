using MarsRover.MapCore;
using MarsRover.Model;
using MarsRover.Reader;
using MarsRover.Writer;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public class RoverCore
    {
        private readonly IConfiguration _configuration;
        private readonly IAudit _fileLogger;
        private readonly IReader _reader;

      


        public RoverCore(IConfiguration configuration, IReader reader, IAudit file)
        {
            _configuration = configuration;
            _reader = reader;
            _fileLogger = file;
        }

        public void Engine()
        {
            //Inizializza info geografiche
            var tuplaOstacoli = MapDrawer._arrayTupleOstacoli;
            var listaComandi = _reader.GetComandiFromCSV(_configuration["pathnameInput"]).ToList();
            var larghezzaMappa = MapDrawer._larghezzaMappa;
            var altezzaMappa = MapDrawer._altezzaMappa;
            MapInformation marsMap = new MapInformation(tuplaOstacoli, larghezzaMappa, altezzaMappa);

            //Inizializza coordinate iniziali
            var coordinateIniziali = new CoordinateRover(MapDrawer._initialRoverX, MapDrawer._initialRoverY, MapDrawer._initialDirection, false);

            //Inizializza rover
            Rover myRover = new Rover("Curiosity", coordinateIniziali);

            //Prendi singoli comandi dal file
            Char[] elencoComandi = listaComandi[0].ToUpper().ToCharArray();

            //Cicla i comandi e ottieni una coordinata
           for (var i=0; i<elencoComandi.Length; i++)
            {
                //Analizza ultima posizione nota e ottieni nuova coordinata
                var nuovaPosizione = ChainCommandAnalysis.NewCoordinates(elencoComandi[i], myRover, marsMap);

                myRover.Coordinates.CoordinataX = nuovaPosizione.Item1;
                myRover.Coordinates.CoordinataY = nuovaPosizione.Item2;
                myRover.Coordinates.Direzione = nuovaPosizione.Item3;
                myRover.Coordinates.Stuck = nuovaPosizione.Item4;

                //Console logga coordinata + scrivi su stesso file la coordinata
                _fileLogger.Log(myRover);
            }
        }

        public string GeneratoreFrasiDiAbbandono()
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

            return frasi[rnd.Next(0, frasi.Length)];
        }

    }
}
