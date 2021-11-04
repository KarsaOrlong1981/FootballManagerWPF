using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootballManager2021
{
    public class Leagues
    {
      
        Club club;
        List<Club> leagueEngland;
       
        public Leagues()
        {
            club = new Club();
            leagueEngland = new List<Club>();
           
        }
        public void AddnewPlayerToTeam(List<Player> team, Player player)
        {
            team.Add(player);
        }
        public void RemovePlayerFromTeam(List<Player> team, Player player)
        {
            team.Remove(player);
        }
      
       
        //Diese Methode verwende ich zum erstellen aller möglichen Clubs, egal welche Liga und welches land
        private Club CreateNewClub(string name, string league, int strength, int fansCount, int loyality, SolidColorBrush color1, SolidColorBrush color2, SolidColorBrush color3, List<Player> member) 
        {
            club = new Club();
            club.ClubName = name;
            club.ClubLeague = league;
            club.ClubStrength = strength;
            club.FansCount = fansCount;
            club.FansLoyality = loyality;
            club.ClubColorMain = color1;
            club.ClubColorSec = color2;
            club.ClubColorThird = color3;
            club.TeamPlayer = member;
            return club;
        }
        //Diese methode erweitert die Liste der Englischen liga
        public List<Club> England(List<Player> team, string name, int bm_count, int bm_loyality, SolidColorBrush color1, SolidColorBrush color2, SolidColorBrush color3)
        {
            int overallStrength = club.GetClubStrength(team);
            int fansCount = club.GetFansCount(bm_count);
            int fansLoyality = club.GetFansLoyality(bm_loyality);

            leagueEngland.Add(CreateNewClub(name, "England", overallStrength, fansCount, fansLoyality, color1, color2, color3, team));
            return leagueEngland;
        }
       
      
       
    }
}
