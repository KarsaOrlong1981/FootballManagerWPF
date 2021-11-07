using System;
using System.Collections.Generic;
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
        List<Player> myPlayer;
        List<Club> leagueTeams;
        Club myClub;
        public MyTeamWindow(List<Player> myPlayer,List<Club> leagueTeams)
        {
            InitializeComponent();
            this.myPlayer = myPlayer;
            this.leagueTeams = leagueTeams;
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

        }

        private void btnViewTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamView teamview = new TeamView(myPlayer);

            teamview.Show();
        }

        private void btnViewMatches_Click(object sender, RoutedEventArgs e)
        {
            Matches matches = new Matches(leagueTeams, myClub);
           
            matches.Show();
            matches.GetMatchesForSaison();
        }

        private void btnViewMatchesMyTeam_Click(object sender, RoutedEventArgs e)
        {
            Matches matches = new Matches(leagueTeams, myClub);
           
            matches.Show();
            matches.GetMatchesForMyTeam();
        }
    }
}
