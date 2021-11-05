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
        Club[,] repertoire;
        public Matches(List<Club> league)
        {
            InitializeComponent();
            // Den Spielplan aufnehmen
            matchday = new MatchDay(league);
            this.repertoire = matchday.Repertoire(league);
            GetMatchesForSaison();
        }
        void GetMatchesForSaison()
        {
            int row = 0;
            int column = 0;
            
            foreach (var club in repertoire)
            {
              
                Label match = new Label
                {
                    Content = club.ClubName,
                    Foreground = Brushes.Black,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch
                };
                ColumnDefinition col1 = new ColumnDefinition();
                col1.Width = new GridLength(1, GridUnitType.Auto);
                RowDefinition row1 = new RowDefinition();
                row1.Height = new GridLength(1, GridUnitType.Auto);
                grid.RowDefinitions.Add(row1);
                grid.ColumnDefinitions.Add(col1);
                
                Grid.SetColumn(match, column);
                Grid.SetRow(match, row);
                grid.Children.Add(match);
                
               
                column++;
                if (column > 1)
                {
                    column = 0;
                    row++;
                }
            }
            
        }
    }
}
