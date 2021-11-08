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
        MatchDayClass matchday;
        List<string> repFirstRound, repSecondRound;
        Club myTeam;
        List<Club> league;
        SolidColorBrush matchDayColor, lines;
        List<string> myTeamRounds, awayTeamsFR, myteamSR, awayTeamSR;
        public Matches(List<Club> league, Club myTeam)
        {
            InitializeComponent();
            // Den Spielplan aufnehmen
            myTeamRounds = new List<string>();
            awayTeamsFR = new List<string>();
          
            matchDayColor = new SolidColorBrush();
            lines = new SolidColorBrush();
            this.league = league;
            this.myTeam = myTeam;
            matchday = new MatchDayClass(league);
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
           
           
        }
        public string GetNextMatchForMyTeam(string matchDay)
        {
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
            GetMatchesForMyTeam();
            string nextMatch = string.Empty;
            for (int i = 0; i < myTeamRounds.Count; i++)
            {
                if (myTeamRounds[i] == matchDay)
                {
                    nextMatch = myTeamRounds[i + 1];
                    break;
                }
            }

            return nextMatch;
        }
        public List<string> GetnextMatchDayForAllTeams(string matchDay)
        {
            List<string> nextMatchDayForAll = new List<string>();
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
            for (int i = 0; i < repFirstRound.Count; i++)
            {
                if (repFirstRound[i].Contains(matchDay))
                {
                    int counter = i;
                    int leagueSize = league.Count / 2; //die größe der Liga geteilt durch 2 enspricht der Anzahl aller Spiele eines Spieltages
                    for (int y = 0; y < leagueSize; y++)//Extrahiert die nächsten 10 Spiel nachdem der letzte string Spieltag Var enthalten hat.....
                    {
                       nextMatchDayForAll.Add(repFirstRound[counter]);
                       counter++;
                    }
                }
            }
            //Wenn wir uns schon in der Rückrunde befinden auch hier den gesuchten Spieltag finden
            for (int i = 0; i < repSecondRound.Count; i++)
            {
                if (repSecondRound[i].Contains(matchDay))
                {
                    int counter = i;
                    int leagueSize = league.Count / 2; //die größe der Liga geteilt durch 2 enspricht der Anzahl aller Spiele eines Spieltages
                    for (int y = 0; y < leagueSize; y++)//Extrahiert die nächsten 10 Spiel nachdem der letzte string Spieltag Var enthalten hat.....
                    {
                        nextMatchDayForAll.Add(repSecondRound[counter]);
                        counter++;
                    }
                }
            }
            return nextMatchDayForAll;
        }
        public void GetMatchesForMyTeam()
        {
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
            int row = 0;
            int myMatchDayCount = 1;
            string myMatch = string.Empty;
            foreach (var match in repFirstRound)
            {
                if (match.Contains(myTeam.ClubName))
                {
                    myTeamRounds.Add("Spieltag " + myMatchDayCount);
                    myTeamRounds.Add(match);
                    myMatchDayCount++;
                }
            }
            foreach (var match in repSecondRound)
            {
                if (match.Contains(myTeam.ClubName))
                {
                    myTeamRounds.Add("Spieltag " + myMatchDayCount);
                    myTeamRounds.Add(match);
                    myMatchDayCount++;
                }
            }

            //Hinrunde mein Team
            foreach (var match in myTeamRounds )
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
            repFirstRound = matchday.GetFirstRound(league);
            repSecondRound = matchday.GetSecondRound(league);
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
