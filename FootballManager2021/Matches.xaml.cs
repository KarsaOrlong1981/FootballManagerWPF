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
    /// Interaktionslogik für Matches.xaml
    /// </summary>
    public partial class Matches : Window
    {
        MatchDay matchday;
        List<string> repFirstRound, repSecondRound;
        Club myTeam;
        List<Club> league;
        SolidColorBrush matchDayColor, lines;
        List<string> myTeamFR, awayTeamsFR, myteamSR, awayTeamSR;
        public Matches(List<Club> league, Club myTeam)
        {
            InitializeComponent();
            // Den Spielplan aufnehmen
            myTeamFR = new List<string>();
            awayTeamsFR = new List<string>();
          
            matchDayColor = new SolidColorBrush();
            lines = new SolidColorBrush();
            this.league = league;
            this.myTeam = myTeam;
            matchday = new MatchDay(league);
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
           
           
        }
        public void GetMatchesForMyTeam()
        {
           
            int row = 0;
            int myMatchDayCount = 1;
            string myMatch = string.Empty;
            foreach (var match in repFirstRound)
            {
                if (match.Contains(myTeam.ClubName))
                {
                    myTeamFR.Add("Spieltag " + myMatchDayCount);
                    myTeamFR.Add(match);
                    myMatchDayCount++;
                }
            }
            foreach (var match in repSecondRound)
            {
                if (match.Contains(myTeam.ClubName))
                {
                    myTeamFR.Add("Spieltag " + myMatchDayCount);
                    myTeamFR.Add(match);
                    myMatchDayCount++;
                }
            }

            //Hinrunde mein Team
            foreach (var match in myTeamFR )
            {
                if (row % 2 == 0)
                {
                    lines = Brushes.LightGray;
                }
                else
                {
                    lines = Brushes.LightCyan;
                }
                if (match.Substring(0, 5) == "Spiel")
                {
                    matchDayColor = Brushes.Black;
                   
                }
                else
                {
                    matchDayColor = Brushes.Black;
                }
                
                Label lbl_Match = new Label
                {
                    Content = match,
                    Background = lines,
                    Foreground = matchDayColor,
                    FontSize = 20.0,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Center

                };

                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(1, GridUnitType.Auto);
                grid.RowDefinitions.Add(row1);
                Grid.SetRow(lbl_Match, row);

                grid.Children.Add(lbl_Match);
                row++;
            }
         

        }
        public void GetMatchesForSaison()
        {
            int row = 0;
           
            foreach (var game in repFirstRound)
            {
                if (row % 2 == 0)
                {
                    lines = Brushes.LightCyan;
                }
                else
                {
                    lines = Brushes.LightGray;
                }
                if (game.Substring(0,5) == "Spiel")
                {
                    matchDayColor = Brushes.White;
                    lines = Brushes.Black;
                }
                else
                {
                    matchDayColor = Brushes.Black;
                }
               
                
                Label match = new Label
                {
                    Content = game,
                    Foreground = matchDayColor,
                    Background = lines,
                    FontSize = 20.0,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Center
                    
                };
               
                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(1, GridUnitType.Auto);
                grid.RowDefinitions.Add(row1);
                Grid.SetRow(match, row);
               
                grid.Children.Add(match);
                row++;
            }
            foreach (var game in repSecondRound)
            {
                if (row % 2 == 0)
                {
                    lines = Brushes.LightCyan;
                }
                else
                {
                    lines = Brushes.LightGray;
                }
                if (game.Substring(0, 5) == "Spiel")
                {
                    matchDayColor = Brushes.White;
                    lines = Brushes.Black;
                }
                else
                {
                    matchDayColor = Brushes.Black;
                }
               
                
                Label match = new Label
                {
                    Content = game,
                    Foreground = matchDayColor,
                    Background = lines,
                    FontSize = 20.0,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    HorizontalContentAlignment = HorizontalAlignment.Center
                };

                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(1, GridUnitType.Auto);
                grid.RowDefinitions.Add(row1);
                Grid.SetRow(match, row);
               
                grid.Children.Add(match);
                row++;
            }


        }
    }
}
