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
        private List<Player> manU;
        private List<Player> lndonClocks;
        private List<Club> league;
        CreatClubs creat;
        public MainWindow()
        {
            InitializeComponent();
         
            

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            TeamView teamview = new TeamView();
            this.Close();
            teamview.Show();
        }
    }
}
