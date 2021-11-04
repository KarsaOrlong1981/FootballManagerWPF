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
        private List<Club> league;
        CreatClubs creat;
        public TeamView()// diesem konstrukor muss ich die beiden Teams übergeben,,,,später
        {
            InitializeComponent();
            creat = new CreatClubs();
            //creat.CreatNewFileEngland("england.txt");
            league = creat.LoadFileEngland("england.txt");
            this.Title = league[0].ClubName;
            //manU = league[0].TeamPlayer;
            //lndonClocks = league[1].TeamPlayer;
            new MatchResult(league[0].TeamPlayer, league[1].TeamPlayer);
            foreach ( var player in league[0].TeamPlayer)
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
        }

       

        private void listName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           var name = (sender as ListView).SelectedItem ;
            allPlayersGrid.Visibility = Visibility.Collapsed;
            PlayerCard(Convert.ToString(name));
            Debug.WriteLine("Der geklickte Name: " + name);
        }
        void PlayerCard(string playerName)
        {
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
                Source = new BitmapImage(new Uri("pics/girl30.png", UriKind.Relative)),
                HorizontalAlignment = HorizontalAlignment.Left,
                Width = 30,
                Height = 30,
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
    }
}
