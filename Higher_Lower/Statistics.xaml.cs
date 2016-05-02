using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Higher_Lower
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        Game game = new Game();

        public Statistics()
        {
            InitializeComponent();
            ObservableCollection<DataObject> list = new ObservableCollection<DataObject>();

            list.Add(new DataObject() { Rank = "1.", Score = game.highScoreArray[0] });
            list.Add(new DataObject() { Rank = "2.", Score = game.highScoreArray[1] });
            list.Add(new DataObject() { Rank = "3.", Score = game.highScoreArray[2] });
            list.Add(new DataObject() { Rank = "4.", Score = game.highScoreArray[3] });
            list.Add(new DataObject() { Rank = "5.", Score = game.highScoreArray[4] });
            list.Add(new DataObject() { Rank = "6.", Score = game.highScoreArray[5] });
            list.Add(new DataObject() { Rank = "7.", Score = game.highScoreArray[6] });
            list.Add(new DataObject() { Rank = "8.", Score = game.highScoreArray[7] });
            list.Add(new DataObject() { Rank = "9.", Score = game.highScoreArray[8] });
            list.Add(new DataObject() { Rank = "10.", Score = game.highScoreArray[9] });

            this.dataGrid.ItemsSource = list;
        }

        public class DataObject
        {
            public string Rank { get; set; }
            public int Score { get; set; }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Hide();
            menu.Show();
        }
    }
}
