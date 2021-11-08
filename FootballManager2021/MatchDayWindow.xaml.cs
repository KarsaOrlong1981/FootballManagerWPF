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
    /// Interaktionslogik für MatchDayWindow.xaml
    /// </summary>
    public partial class MatchDayWindow : Window
    {
        Matches matches;
        MatchResult result;
        List<Club> league;
        List<Player> teamA, teamB;
        public MatchDayWindow(bool myTeamMatch, bool allTeamsMatch, List<Club> league, Club myTeam) // hier muss noch der aktuelle Spieltag übergeben werden
        {
            InitializeComponent();
            matches = new Matches(league, myTeam);
            this.league = league;
            teamA = new List<Player>();
            teamB = new List<Player>();
            if (myTeamMatch == true)
            {
                GetMyTeamNextMatchResult("Spieltag 1");
            }
        }
        private void GetMyTeamNextMatchResult(string matchDay)
        {
            //Hier muss ich noch die Torschützen und Vorlagengeber ausgeben lassen + eine Methode um die Ergebnisse und Torschützen + Vorlagengeber aller anderen partien auszugeben
            string nextMatch = string.Empty;
            nextMatch = matches.GetNextMatchForMyTeam(matchDay);
            string[] teams = nextMatch.Split('-');
            foreach (var club in league)
            {
                if (teams[0] == club.ClubName)
                {
                    teamA = club.TeamPlayer;
                }
                if (teams[1] == club.ClubName)
                {
                    teamB = club.TeamPlayer;
                }
            }
            result = new MatchResult(teamA, teamB);
            Label labA = new Label 
            {
                Content = teams[0],
                FontSize = 25.0,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Label labB = new Label
            {
                Content = teams[1],
                FontSize = 25.0,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Label labLine = new Label
            {
                Content = " - ",
                FontSize = 25.0,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            string finalResult = result.GetFinalresult();
            Label labFinalRes = new Label
            {
                Content = finalResult,
                FontSize = 25.0,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            Grid.SetColumn(labA, 0);
            Grid.SetRow(labA, 0);
            Grid.SetColumn(labLine, 1);
            Grid.SetRow(labLine, 0);
            Grid.SetColumn(labB, 2);
            Grid.SetRow(labB, 0);
            Grid.SetColumn(labFinalRes, 3);
            Grid.SetRow(labB, 0);

            grid.Children.Add(labA);
            grid.Children.Add(labLine);
            grid.Children.Add(labB);
            grid.Children.Add(labFinalRes);
            

            Debug.WriteLine(nextMatch);
        }
    }
}
