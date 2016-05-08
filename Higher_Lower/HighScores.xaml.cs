﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Higher_Lower
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        Game game = new Game();
        ObservableCollection<DataObject> list = new ObservableCollection<DataObject>();

        public HighScores()
        {
            InitializeComponent();

            this.dataGrid.ItemsSource = list;
        }

        public void Highscores_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\philip\Documents\Visual Studio 2015\Projects\Higher_Lower\Higher_Lower\highscore.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    game.highscoreList.Add(int.Parse(line));
                }
            }

            for (int x = 1; x < 11; x++)
            {
                if (game.highscoreList.Count > x-1)
                {
                    list.Add(new DataObject() { Rank = x + ".", Score = game.highscoreList[x - 1].ToString() });
                }
                else
                {
                    list.Add(new DataObject() { Rank = x + ".", Score = "" });
                }
            }
        }

        public class DataObject
        {
            public string Rank { get; set; }
            public string Score { get; set; }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Hide();
            menu.Show();
        }
    }
}
