using System;
using System.Collections.Generic;
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

namespace Higher_Lower
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();
        HighScores highscores = new HighScores();

        public MainWindow()
        {
            InitializeComponent();
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            game.Show();
        }

        private void Highscores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            highscores.Show();
        }
    }
}
