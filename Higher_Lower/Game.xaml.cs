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

namespace Higher_Lower
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        public Game()
        {
            InitializeComponent();
        }

        int sum = 0;
        Deck thing = new Deck();
        
        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            string happy = thing.result();

            if (sum != 100)
            {
                if (happy == "add")
                {
                    sum += 10;
                    textBox.Text = sum.ToString();
                }
                else if (happy == "equal")
                {
                    textBox.Text = sum.ToString();
                }
                else
                {
                    sum -= 10;
                    textBox.Text = sum.ToString();
                }
            }
            else
            {
                MessageBox.Show("Congratulations!!!!");
            }
        }

        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            string happy = thing.result();

            if (sum != 100)
            {
                if (happy == "sub")
                {
                    sum += 10;
                    textBox.Text = sum.ToString();
                }
                else if (happy == "equal")
                {
                    textBox.Text = sum.ToString();
                }
                else
                {
                    sum -= 10;
                    textBox.Text = sum.ToString();
                }
            }
            else
            {
                MessageBox.Show("Congratulations!");
            }
        }
    }
}
