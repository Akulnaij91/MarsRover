using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Core
{
    public static class ChangeRoverPositionHandler
    {
        public static (int,int,char,bool) NewCoordinates(char command,(int,int) roverPosition, char actualOrientation, List<(int x, int z)> elencoOstacoli, int larghezzaMappa, int altezzaMappa)
        {
            if (command=='L' || command =='R')
            {
                return (roverPosition.Item1,roverPosition.Item2, RotationHandler(command, actualOrientation),false);
            } 
            else
            {
                //posizione attuale + movimento = nuova posizione
                var nuoveCoordinate = MovementHandler(command,roverPosition,actualOrientation,elencoOstacoli);

                //se nuova posizione non è contenuta in elenco ostacoli, checka effetto pacman, altrimenti ritornala
                if (!elencoOstacoli.Contains(nuoveCoordinate))
                {
                    
                    if (nuoveCoordinate.Item1>=larghezzaMappa) //Pacman -> vado a destra
                    {
                        nuoveCoordinate.Item1 = 0;
                    } 
                    else if (nuoveCoordinate.Item1<0) //Pacman -> vado a sinistra
                    {
                        nuoveCoordinate.Item1 = larghezzaMappa-1;
                    } 
                    else if (nuoveCoordinate.Item2>= altezzaMappa) //Pacman -> vado a sotto
                    {
                        nuoveCoordinate.Item2 = 0;
                    } 
                    else if(nuoveCoordinate.Item2 < 0) //Pacman -> vado a sopra
                    {
                        nuoveCoordinate.Item2 = altezzaMappa - 1;
                    }
                    
                    return (nuoveCoordinate.Item1, nuoveCoordinate.Item2, actualOrientation,false);

                }
                else //se posizione è contenuta, sono bloccato ritorna posizione attuale
                {
                    return (roverPosition.Item1, roverPosition.Item2, actualOrientation,true);
                }
            }
        }



        public static (int,int) MovementHandler(char command, (int,int) roverPosition, char actualOrientation, List<(int x, int z)> ostacoli)
        {
            if (command=='F' && actualOrientation=='N')
            {
                return (roverPosition.Item1, roverPosition.Item2 - 1);
            }
            else if (command == 'B' && actualOrientation == 'N')
            {
                return (roverPosition.Item1, roverPosition.Item2 + 1);
            }
            else if(command == 'F' && actualOrientation == 'S')
            {
                return (roverPosition.Item1, roverPosition.Item2 + 1);
            }
            else if(command == 'B' && actualOrientation == 'S')
            {
                return (roverPosition.Item1, roverPosition.Item2 - 1);
            }


            else if(command == 'F' && actualOrientation == 'E')
            {
                return (roverPosition.Item1+1, roverPosition.Item2);
            }
            else if(command == 'B' && actualOrientation == 'E')
            {
                return (roverPosition.Item1-1, roverPosition.Item2);
            }
            else if(command == 'F' && actualOrientation == 'W')
            {
                return (roverPosition.Item1-1, roverPosition.Item2);
            }
            else 
            {
                return (roverPosition.Item1+1, roverPosition.Item2);
            }


        }

        public static char RotationHandler(char command, char actualOrientation)
        {

            if (actualOrientation =='N' && command == 'L')
            {
                return 'W';
            }
            else if (actualOrientation == 'E' && command == 'L')
            {
                return 'N';
            }
            else if(actualOrientation == 'W' && command == 'L')
            {
                return 'S';
            }
            else if (actualOrientation == 'S' && command == 'L')
            {
                return 'E';
            }

            else if(actualOrientation == 'N' && command == 'R')
            {
                return 'E';
            }
            else if(actualOrientation == 'E' && command == 'R')
            {
                return 'S';
            }
            else if(actualOrientation == 'W' && command == 'R')
            {
                return 'N';
            }
            else 
            {
                return 'W';
            }


        }





    }
}
