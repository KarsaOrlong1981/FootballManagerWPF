using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager2021
{
    public class MatchDay
    {
        List<Club> league;

        Club[] rep;
        
        Club[,] repertoire;
        public MatchDay(List<Club> league)
        {
            this.league = league;
            //erstellung des Spielplans jeder gegen jeden
            repertoire = new Club[league.Count * (league.Count - 1), 2];
            rep = new Club[league.Count];
            rep = GetClubsFromLeague();
           
          
        }
        
        public Club[] GetClubsFromLeague()
        {
            int count = 0;
            foreach (var club in league)
            {
                rep[count] = club;
                count++;
            }
            return rep;
        }
        
        public Club[,] Repertoire(List<Club> league)
        {
            int counter = 0;
            for (int a = 0; a < league.Count; a++)
            {

                for (int i = 0; i < league.Count; i++)
                {

                    if (league[a] == league[i])
                        continue;
                    else

                    {
                        repertoire[counter, 0] = league[a];
                        repertoire[counter, 1] = league[i];
                    }
                    counter++;
                }
            }
            return repertoire;

        }
    }
}
