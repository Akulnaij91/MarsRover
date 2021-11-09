using MarsRover.MapCore;
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
            var tuplaOstacoli = MapDrawer._arrayTupleOstacoli ;
            var listaComandi = _reader.GetComandiFromCSV(_configuration["pathnameInput"]).ToList();
            //Prendi singoli comandi
            Char[] elencoComandi = listaComandi[0].ToUpper().ToCharArray();

            var ultimaPosizioneNota = (MapDrawer._initialRoverX, MapDrawer._initialRoverY);
            var ultimaDirezione = MapDrawer._initialDirection;
            var larghezzaMappa = MapDrawer._larghezzaMappa;
            var altezzaMappa = MapDrawer._altezzaMappa;




            //Cicla i comandi e ottieni una coordinata
           for (var i=0; i<elencoComandi.Length; i++)
            {
                //Analizza ultima posizione nota e ottieni nuova coordinata
                var nuovaPosizione = ChangeRoverPositionHandler.NewCoordinates(elencoComandi[i], ultimaPosizioneNota,ultimaDirezione,tuplaOstacoli,larghezzaMappa,altezzaMappa);

                ultimaPosizioneNota.Item1 = nuovaPosizione.Item1;
                ultimaPosizioneNota.Item2 = nuovaPosizione.Item2;
                ultimaDirezione = nuovaPosizione.Item3;
                var bloccato = nuovaPosizione.Item4;

                //Console logga coordinata + scrivi su stesso file la coordinata
                _fileLogger.Log(ultimaPosizioneNota.Item1, ultimaPosizioneNota.Item2, ultimaDirezione, bloccato);
            }



            



        }

    }
}
