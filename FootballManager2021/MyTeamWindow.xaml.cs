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
        List<Player> myClub;
        List<Club> leagueTeams;
        public MyTeamWindow(List<Player> myClub,List<Club> leagueTeams)
        {
            InitializeComponent();
            this.myClub = myClub;
            this.leagueTeams = leagueTeams;
        }

        private void btnNextMatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewTeam_Click(object sender, RoutedEventArgs e)
        {
            TeamView teamview = new TeamView(myClub);

            teamview.Show();
        }

        private void btnViewMatches_Click(object sender, RoutedEventArgs e)
        {
            Matches matches = new Matches(leagueTeams);
            matches.Show();
        }
    }
}
