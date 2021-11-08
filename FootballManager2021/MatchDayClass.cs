using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager2021
{
    public class MatchDayClass
    {
        List<Club> league;
      
        Club[] rep;
        List<string> clubsFR, clubsSR;
        Club[,] repertoire;
        public MatchDayClass(List<Club> league)
        {
            this.league = league;
            //erstellung des Spielplans jeder gegen jeden
            clubsFR = new List<string>();
            clubsSR = new List<string>();
         
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
        
        public List<string> GetFirstRound(List<Club> league)
        {
            string[] teams = new string[league.Count];
            int count = 0;
            foreach (var club in league)
            {
                teams[count] = club.ClubName;
                count++;
            }
            int n = teams.Length - 1;
            for (int i = 1; i < (n + 1); i++)
            {
                clubsFR.Add("Spieltag " + i);
                if (i % 2 == 0)
                {
                    printMatchFR(teams[i - 1], teams[n]);
                }
                else
                {
                    printMatchFR(teams[n], teams[i - 1]);
                }
                for (int k = 1; k < (n + 1) / 2; k++)
                {
                    int tmp = (i + k) % n;
                    int teamA = tmp == 0 ? n : tmp;
                    tmp = ((i - k % n) + n) % n;
                    int teamB = tmp == 0 ? n : tmp;
                    if (k % 2 != 0)
                    {
                        printMatchFR(teams[teamA - 1], teams[teamB - 1]);
                    }
                    else
                    {
                        printMatchFR(teams[teamB - 1], teams[teamA - 1]);
                    }
                }
            }

         
            return clubsFR;

        }
        public List<string> GetSecondRound(List<Club> league)
        {

            string[] teams = new string[league.Count];
            int count = 0;
            foreach (var club in league)
            {
                teams[count] = club.ClubName;
                count++;
            }
            int n = teams.Length - 1;
            //Console.WriteLine("----HINRUNDE----");
            int matchdayCount = league.Count;
            for (int i = 1; i < (n + 1); i++)
            {
                clubsSR.Add("Spieltag " + matchdayCount);
                if (i % 2 == 0)
                {
                    printMatchSR(teams[n], teams[i - 1]);
                }
                else
                {
                    printMatchSR(teams[i - 1], teams[n]);
                }
                for (int k = 1; k < (n + 1) / 2; k++)
                {
                    int tmp = (i + k) % n;
                    int teamA = tmp == 0 ? n : tmp;
                    tmp = ((i - k % n) + n) % n;
                    int teamB = tmp == 0 ? n : tmp;
                    if (k % 2 != 0)
                    {
                        printMatchSR(teams[teamB - 1], teams[teamA - 1]);
                    }
                    else
                    {
                        printMatchSR(teams[teamA - 1], teams[teamB - 1]);
                    }
                }
                matchdayCount++;
            }

          
            return clubsSR;

        }
        private  void printMatchFR(String teamA, String teamB)
        {
            clubsFR.Add(teamA + "-" + teamB);
        }
        private void printMatchSR(String teamA, String teamB)
        {

            clubsSR.Add(teamA + "-" + teamB);
          

        }
    }
}
