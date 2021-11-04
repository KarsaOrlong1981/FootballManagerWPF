using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FootballManager2021
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Player> actualClub;
        
        private List<Club> league;
        CreatClubs creat;
        public MainWindow()
        {
            InitializeComponent();

            creat = new CreatClubs();

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {

            TeamView teamview = new TeamView(actualClub);
            
            teamview.Show();
        }

        private void btnliga_Click(object sender, RoutedEventArgs e)
        {
            btnliga.Visibility = Visibility.Hidden;
            btnEngland.Visibility = Visibility.Visible;
        }

        private void btnTeam_Click(object sender, RoutedEventArgs e)
        {
            btnTeam.Visibility = Visibility.Collapsed;
            int row = 0;
            foreach (var club in league)
            {
                Button btnX = new Button
                {
                    Content = club.ClubName,

                };
                btnX.Click += BtnX_Click;
                Grid.SetColumn(btnX, 1);
                Grid.SetRow(btnX, row);
                grid.Children.Add(btnX);
                row++;
            }
        }

        private void BtnX_Click(object sender, RoutedEventArgs e)
        {
            string clubName = Convert.ToString((sender as Button).Content);
            foreach (var club in league)
            {

                if (clubName == club.ClubName)
                {
                    actualClub = club.TeamPlayer;
                }
            }
           MyTeamWindow myTeam = new MyTeamWindow(actualClub, league);
            this.Close();
            myTeam.Title = clubName;
            myTeam.Show();

        }
        private void btnEngland_Click(object sender, RoutedEventArgs e)
        {
            btnEngland.Visibility = Visibility.Hidden;
            MessageBoxResult quest = MessageBox.Show("Wollen Sie eine neue Enlische liga mit neuen Zufällig erstellten Spielern erstellen ?", "Neues Spiel", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (quest == MessageBoxResult.Yes)
            {
                creat.CreatNewFileEngland("england.txt");
                league = creat.LoadFileEngland("england.txt");
            }
            else
            {
                league = creat.LoadFileEngland("england.txt");
            }
            btnTeam.Visibility = Visibility.Visible;

        }
    }
}
