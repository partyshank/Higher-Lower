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
            // added cause I saw it on the internet when looking for how to do things onload. necessary yeah?
            Loaded += Game_Loaded;
        }

        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            // generates a random initial card to start the game upon window load.
            textBox1.Text = thing.random();
            textBox1.FontWeight = FontWeights.Bold;
            textBox1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
        }

        private void reset()
        {
            for (int k=0; k<textBoxList.Count; k++)
            {
                textBoxList[k].Text = string.Empty;
            }
            score = 0;
            guesses = 0;
            index = 1;
            textBox.Text = score.ToString();
            textBoxList[0].Text = thing.random();
            textBoxList[0].FontWeight = FontWeights.Bold;
            textBoxList[0].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));

        }

        // list of textboxes so i could index them and cycle through upon click event.
        List<TextBox> textBoxList = new List<TextBox>();

        //initialising score
        int score = 0;
        //initialising guesses
        int guesses = 0;
        //index for textbox array, initialised at index 1 because textbox at index 0 is generated on window load, but need it within array to create a loop
        int index = 1;
        Deck thing = new Deck();
        bool doublePoints = true;
        int highScore;
        public List<int> highScoreArray = new List<int>();

      
        // higher_click and lower_click contain almost identical code. 
        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            guesses += 1;
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);

            //using index will always add text to the second textbox on first click. increment index of textbox array on 
            //each click so appends text to the next textbox in array
            textBoxList[index].Text = thing.random();
            textBoxList[index].FontWeight = FontWeights.Bold;
            textBoxList[index].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
            textBoxList[index - 1].Foreground = Brushes.White;
            textBoxList[index - 1].FontWeight = FontWeights.Normal;

            string[] cardValueCurrentArrayString = textBoxList[index].Text.Split(' ');
            string[] cardValuePreviousArrayString = textBoxList[index - 1].Text.Split(' ');

            if (cardValueCurrentArrayString[0] == "Ace")
            {
                cardValueCurrentArrayString[0] = "1";
            }

            if (cardValueCurrentArrayString[0] == "Jack")
            {
                cardValueCurrentArrayString[0] = "11";
            }

            if (cardValueCurrentArrayString[0] == "Queen")
            {
                cardValueCurrentArrayString[0] = "12";
            }

            if (cardValueCurrentArrayString[0] == "King")
            {
                cardValueCurrentArrayString[0] = "13";
            }

            //seksksksksksksksksk

            if (cardValuePreviousArrayString[0] == "Ace")
            {
                cardValuePreviousArrayString[0] = "1";
            }

            if (cardValuePreviousArrayString[0] == "Jack")
            {
                cardValuePreviousArrayString[0] = "11";
            }

            if (cardValuePreviousArrayString[0] == "Queen")
            {
                cardValuePreviousArrayString[0] = "12";
            }

            if (cardValuePreviousArrayString[0] == "King")
            {
                cardValuePreviousArrayString[0] = "13";
            }

            int cardValueCurrent = int.Parse(cardValueCurrentArrayString[0]);
            int cardValuePrevious = int.Parse(cardValuePreviousArrayString[0]);

            index += 1;

            //if the next index is not represented by a textbox, the next click will append text to the textbox at index 0
            if (index == (textBoxList.Count - 1))
            {
                index = 0;
            }

            // scoring system, check out result() for reference
            if (doublePoints)
            {
                if (cardValueCurrent > cardValuePrevious)
                {
                    score += 10;
                    textBox.Text = score.ToString();
                    if (score >= 100)
                    {
                        MessageBox.Show("Congratulations!");
                        highScore = guesses;
                        if (highScoreArray.Count == 10)
                        {
                            highScoreArray.Remove(highScoreArray.Max());
                            highScoreArray.Add(highScore);
                        }
                        else
                        {
                            highScoreArray.Add(highScore);
                        }
                        highScoreArray.Sort();
                        for (int a = 0; a < highScoreArray.Count; a++)
                        {
                            MessageBox.Show(highScoreArray[a].ToString());
                        }
                        reset();
                    }
                }
                else if (cardValueCurrent == cardValuePrevious)
                {
                    MessageBox.Show("Double Points!");
                    doublePoints = false;
                    guesses -= 1;
                }
                else
                {
                    score -= 10;
                    textBox.Text = score.ToString();
                }
            }
            else
            {
                if (cardValueCurrent > cardValuePrevious)
                {
                    score += 20;
                    textBox.Text = score.ToString();
                    if (score >= 100)
                    {
                        MessageBox.Show("Congratulations!");
                        highScore = guesses;
                        if (highScoreArray.Count == 10)
                        {
                            highScoreArray.Remove(highScoreArray.Max());
                            highScoreArray.Add(highScore);
                        }
                        else
                        {
                            highScoreArray.Add(highScore);
                        }
                        highScoreArray.Sort();
                        for (int a=0; a<highScoreArray.Count; a++)
                        {
                            MessageBox.Show(highScoreArray[a].ToString());
                        }
                        reset();
                        
                    }
                    doublePoints = true;
                }
                else if (cardValueCurrent == cardValuePrevious)
                {
                    MessageBox.Show("Double Points!");
                    guesses -= 1;
                }
                else
                {
                    score -= 20;
                    textBox.Text = score.ToString();
                    doublePoints = true;
                }
            }
            textBox6.Text = guesses.ToString();
        }
        
        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            guesses += 1;
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);

            textBoxList[index].Text = thing.random();
            textBoxList[index].FontWeight = FontWeights.Bold;
            textBoxList[index].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
            textBoxList[index - 1].Foreground = Brushes.White;
            textBoxList[index - 1].FontWeight = FontWeights.Normal;

            string[] cardValueCurrentArrayString = textBoxList[index].Text.Split();
            string[] cardValuePreviousArrayString = textBoxList[index - 1].Text.Split();

            if (cardValueCurrentArrayString[0] == "Ace")
            {
                cardValueCurrentArrayString[0] = "1";
            }

            if (cardValueCurrentArrayString[0] == "Jack")
            {
                cardValueCurrentArrayString[0] = "11";
            }

            if (cardValueCurrentArrayString[0] == "Queen")
            {
                cardValueCurrentArrayString[0] = "12";
            }

            if (cardValueCurrentArrayString[0] == "King")
            {
                cardValueCurrentArrayString[0] = "13";
            }

            //seksksksksksksksksk

            if (cardValuePreviousArrayString[0] == "Ace")
            {
                cardValuePreviousArrayString[0] = "1";
            }

            if (cardValuePreviousArrayString[0] == "Jack")
            {
                cardValuePreviousArrayString[0] = "11";
            }

            if (cardValuePreviousArrayString[0] == "Queen")
            {
                cardValuePreviousArrayString[0] = "12";
            }

            if (cardValuePreviousArrayString[0] == "King")
            {
                cardValuePreviousArrayString[0] = "13";
            }

            int cardValueCurrent = int.Parse(cardValueCurrentArrayString[0]);
            int cardValuePrevious = int.Parse(cardValuePreviousArrayString[0]);

            index += 1;

            if (index == (textBoxList.Count - 1))
            {
                index = 0;
            }

            if (doublePoints)
            {
                if (cardValueCurrent < cardValuePrevious)
                {
                    score += 10;
                    textBox.Text = score.ToString();
                    if (score >= 100)
                    {
                        MessageBox.Show("Congratulations!");
                        highScore = guesses;
                        if (highScoreArray.Count == 10)
                        {
                            highScoreArray.Remove(highScoreArray.Max());
                            highScoreArray.Add(highScore);
                        }
                        else
                        {
                            highScoreArray.Add(highScore);
                        }
                        highScoreArray.Sort();
                        for (int a = 0; a < highScoreArray.Count; a++)
                        {
                            MessageBox.Show(highScoreArray[a].ToString());
                        }
                        reset();
                    }
                }
                else if (cardValueCurrent == cardValuePrevious)
                {
                    MessageBox.Show("Double Points!");
                    doublePoints = false;
                    guesses -= 1;
                }
                else
                {
                    score -= 10;
                    textBox.Text = score.ToString();
                }
            }
            else
            {
                if (cardValueCurrent < cardValuePrevious)
                {
                    score += 20;
                    textBox.Text = score.ToString();
                    if (score >= 100)
                    {
                        MessageBox.Show("Congratulations!");
                        highScore = guesses;
                        if (highScoreArray.Count == 10)
                        {
                            highScoreArray.Remove(highScoreArray.Max());
                            highScoreArray.Add(highScore);
                        }
                        else
                        {
                            highScoreArray.Add(highScore);
                        }
                        highScoreArray.Sort();
                        for (int a = 0; a < highScoreArray.Count; a++)
                        {
                            MessageBox.Show(highScoreArray[a].ToString());
                        }
                        reset();
                    }
                    doublePoints = true;
                }
                else if (cardValueCurrent == cardValuePrevious)
                {
                    MessageBox.Show("Double Points!");
                    guesses -= 1;
                }
                else
                {
                    score -= 20;
                    textBox.Text = score.ToString();
                    doublePoints = true;
                }
            }
            textBox6.Text = guesses.ToString();
        }

        //returns to main menu, with current game window closing and ending the current game.
        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            this.Hide();
            menu.Show();
        }
    }
}
