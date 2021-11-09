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
            List<string> goalsAssistsA = new List<string>();
            List<string> goalsAssistsB = new List<string>();
           
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
            goalsAssistsA = result.GetGoalsAssistForGameTeamA();
            goalsAssistsB = result.GetGoalsAssistForGameTeamB();
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
            int row = 2;
            foreach (var goal in goalsAssistsA)
            {
                Label labAssistsGoalsA = new Label
                {
                    Content = goal,
                    FontSize = 15.0,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                Grid.SetColumn(labAssistsGoalsA, 0);
                
                Grid.SetRow(labAssistsGoalsA, row);
               
                grid.Children.Add(labAssistsGoalsA);
                row++;
            }
            row = 2;
            foreach (var goal in goalsAssistsB)
            {
                Label labAssistsGoalsB = new Label
                {
                    Content = goal,
                    FontSize = 15.0,
                    HorizontalAlignment = HorizontalAlignment.Stretch
                };
                Grid.SetColumn(labAssistsGoalsB, 2);
               
                Grid.SetRow(labAssistsGoalsB, row);
                
                grid.Children.Add(labAssistsGoalsB);
                row++;
            }


            Debug.WriteLine(nextMatch);
        }
    }
}
