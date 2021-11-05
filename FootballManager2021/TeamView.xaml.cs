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
    /// Interaktionslogik für TeamView.xaml
    /// </summary>
    public partial class TeamView : Window
    {
        
        CreatClubs creat;
        List<Player> club;
        Button backBTN;
        Club strength;
        public TeamView(List<Player> club)// das zweite Team ist nur zu testzwecken hier später wird hier nur ein Team verarbeitet
        {
            InitializeComponent();
            creat = new CreatClubs();
            strength = new Club();
            this.club = club;
           

            this.Title = club[0].ActualClub;
            
            //manU = league[0].TeamPlayer;
            //lndonClocks = league[1].TeamPlayer;
           // new MatchResult(club);
            foreach ( var player in club)
            {
                listPos.Items.Add(player.Position);
                listName.Items.Add(player.Forename + " " + player.Surname);
                listAlter.Items.Add(player.Age);
                listFuss.Items.Add(player.Foot);
                listGewicht.Items.Add(player.Weigth);
                listGr.Items.Add(player.Size);
                listBewer.Items.Add(player.Strength);
                listDef.Items.Add(player.Defense);
                listMid.Items.Add(player.Midfield);
                listAtt.Items.Add(player.Attack);
                listTor.Items.Add(player.GoalKeeping);
                listKst.Items.Add(player.BodyStrength);
                listTac.Items.Add(player.Tactical);
                listTec.Items.Add(player.TechnicSkill);
                listKop.Items.Add(player.Header);
                listSho.Items.Add(player.Shooting);
                listFla.Items.Add(player.Flanks);
                listPas.Items.Add(player.Passing);
                listSpe.Items.Add(player.Speed);
                listMor.Items.Add(player.Moral);
                listTal.Items.Add(player.Talent);
                listFit.Items.Add(player.Fitness);
                listFrm.Items.Add(player.Form);

            }
            int overallStrength = strength.GetClubStrength(club);
            Label stre = new Label
            {
                Content = "Gesamtstärke: " + overallStrength,
                FontSize = 30.0,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Bottom,
                Margin = new Thickness(20),
                Background = Brushes.Black,
                Foreground = Brushes.White
            };
            Button back = new Button
            {
                Content = "Zurück zur Teamansicht",
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Bottom,
                Visibility = Visibility.Hidden
            };
            back.Click += Back_Click;
            backBTN = back;
            playerCardGrid.Children.Add(back);
            playerCardGrid.Children.Add(stre);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            TeamView view = new TeamView(club);
            this.Close();
            view.Show();
        }

        private void listName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            backBTN.Visibility = Visibility.Visible;
            var name = (sender as ListView).SelectedItem ;
            allPlayersGrid.Visibility = Visibility.Hidden;
            
            PlayerCard(Convert.ToString(name), club);
            Debug.WriteLine("Der geklickte Name: " + name);
        }
        void PlayerCard(string playerName, List<Player> team)
        {

            string[] splitName = playerName.Split(' ');
            string avatar = string.Empty;
            foreach (var player in team)
            {
                if (player.Forename == splitName[0] && player.Surname == splitName[1])
                {
                    avatar = player.Avatar;
                    break;
                }
            }
            Grid gridDynamic = new Grid
            {
               HorizontalAlignment = HorizontalAlignment.Stretch,
               VerticalAlignment = VerticalAlignment.Stretch,
               ShowGridLines = true
            };
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(1, GridUnitType.Star);
            ColumnDefinition col2 = new ColumnDefinition();
            col1.Width = new GridLength(1, GridUnitType.Star);
            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(1, GridUnitType.Auto);
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(1, GridUnitType.Auto);
            gridDynamic.ColumnDefinitions.Add(col1);
            gridDynamic.ColumnDefinitions.Add(col2);
            gridDynamic.RowDefinitions.Add(row1);
            gridDynamic.RowDefinitions.Add(row2);

            Image playerIMG = new Image
            {
                Source = new BitmapImage(new Uri(avatar, UriKind.Relative)),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 100,
                Height = 100,
                Margin = new Thickness(20)
                
            };
            Grid.SetColumn(playerIMG, 0);
            Grid.SetRow(playerIMG, 0);
            Label name = new Label
            {
                Content = playerName,
                FontSize = 25.0,
                Background = Brushes.Black,
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                VerticalContentAlignment = VerticalAlignment.Center
            };
           
            Grid.SetColumn(name, 0);
            Grid.SetRow(name, 0);
           
           
            gridDynamic.Children.Add(name);
            gridDynamic.Children.Add(playerIMG);
            playerCardGrid.Children.Add(gridDynamic);
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
