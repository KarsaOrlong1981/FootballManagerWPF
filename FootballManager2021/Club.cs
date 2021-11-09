using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FootballManager2021
{
    
    public class Club
    {
        public string ClubName { get; set; }
        public string ClubLeague { get; set; }
        public int ClubStrength { get; set; }
        public int FansCount { get; set; }
        public int FansLoyality { get; set; }
        public SolidColorBrush ClubColorMain { get; set; }
        public SolidColorBrush ClubColorSec { get; set; }
        public SolidColorBrush ClubColorThird { get; set; }
        public List<Player> TeamPlayer { get; set; }
         
        public Club()
        {
            FansCount = 20000;
            FansLoyality = 5;
        }
        public int GetClubStrength(List<Player> team)
        {
            int overallStrength = 0;
            int memberCounter = 0;
            foreach (var member in team)
            {
                memberCounter++;
                overallStrength = overallStrength + member.Strength;
            }
            ClubStrength = overallStrength / memberCounter;
            return ClubStrength;
        }
        //umso höher die Loyalität der Fans umso Auswärtsstärker wird das Team
        //Heimteams haben immer einen Bonus ausser sie verlieren 4 Spiele hintereinander dann bekommen sie einen Malus
        public int GetFansLoyality(int bonus_malus)
        {
            FansLoyality = FansLoyality + bonus_malus;
            return FansLoyality;
        }
        public int GetFansCount(int bonus_malus)
        {
            FansCount = FansCount + bonus_malus;
            return FansCount;
        }

      
    }
}
