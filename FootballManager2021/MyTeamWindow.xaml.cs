using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FootballManager2021
{
    /// <summary>
    /// Interaktionslogik für MyTeamWindow.xaml
    /// </summary>
    public partial class MyTeamWindow : Window
    {
        List<Player> myPlayer, otherTeam;
        List<Club> leagueTeams;
        Club myClub;
        Matches matches;
        public MyTeamWindow(List<Player> myPlayer,List<Club> leagueTeams)
        {
            InitializeComponent();
            matches = new Matches(leagueTeams, myClub);
            this.myPlayer = myPlayer;
            this.leagueTeams = leagueTeams;
            otherTeam = new List<Player>();
            foreach (var club in leagueTeams)
            {
                if (myPlayer[0].ActualClub == club.ClubName)
                {
                    myClub = club;
                    break;
                }
            }
        }

        private void btnNextMatch_Click(object sender, RoutedEventArgs e)
        {
            MatchDayWindow window = new MatchDayWindow(true, false, leagueTeams, myClub); // parameter 1 schaltet das nächste Match für myTeam, parameter 2 für alle Teams...
            window.Show();
        }

        private void btnViewTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamView teamview = new TeamView(myPlayer);

            teamview.Show();
        }

        private void btnViewMatches_Click(object sender, RoutedEventArgs e)
        {
            matches.Show();
            matches.GetMatchesForSaison();
        }

        private void btnViewMatchesMyTeam_Click(object sender, RoutedEventArgs e)
        {
            matches.Show();
            matches.GetMatchesForMyTeam();
        }
    }
}
