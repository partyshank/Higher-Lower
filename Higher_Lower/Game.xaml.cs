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
            // generates a random initial card to start the game upon window load.
            addTextBox();
            textBoxList[0].Text = thing.random();
            textBoxList[0].FontWeight = FontWeights.Bold;
            textBoxList[0].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
        }

        // list of textboxes so i could index them and cycle through upon click event.
        List<TextBox> textBoxList = new List<TextBox>();

        private List<TextBox> addTextBox()
        {
            textBoxList.Add(textBox1);
            textBoxList.Add(textBox2);
            textBoxList.Add(textBox3);
            textBoxList.Add(textBox4);
            textBoxList.Add(textBox5);

            return textBoxList;
        }

        private void initClick()
        {
            //using index will always add text to the second textbox on first click. increment index of textbox array on 
            //each click so appends text to the next textbox in array
            textBoxList[index].Text = thing.random();
            textBoxList[index].FontWeight = FontWeights.Bold;
            textBoxList[index].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
            textBoxList[previndex].Foreground = Brushes.White;
            textBoxList[previndex].FontWeight = FontWeights.Normal;
        }

        //upon completion of game, resets all back to intial state to start new game.
        private void reset()
        {
            for (int k = 0; k < textBoxList.Count; k++)
            {
                textBoxList[k].Text = string.Empty;
            }
            score = 0;
            guesses = 0;
            index = 0;
            previndex = -1;
            textBox.Text = score.ToString();
            textBoxList[0].Text = thing.random();
            textBoxList[0].FontWeight = FontWeights.Bold;
            textBoxList[0].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));

        }

        int score = 0;
        int guesses = 0;
        //index and previous index for textbox arrays when adding styling.
        int index = 0;
        int previndex = -1;
        Deck thing = new Deck();
        bool doublePoints = false;

        // attempt to store scores into an array to input into table in statistics.xaml
        int highScore;
        public List<int> highScoreArray = new List<int>();

      
        // higher_click and lower_click contain almost identical code. 
        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            guesses += 1;
            index += 1;
            previndex += 1;

            //if the next index is not represented by a textbox, the next click will append text to the textbox at index 0
            if (index == textBoxList.Count)
            {
                index = 0;
            }

            if (previndex == textBoxList.Count)
            {
                previndex = 0;
            }

            initClick();

            //split the text in current and previous textbox eg("2 of Spades") into an array in order to use indexing
            //to convert the rank of card into an integer for use in conditional statements further below.
            string[] cardValueCurrentArrayString = textBoxList[index].Text.Split(' ');
            string[] cardValuePreviousArrayString = textBoxList[previndex].Text.Split(' ');

            //these ranks cannot be converted directly into integers, hence this.
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

            //this is very bulky and messy, will figure out how to neaten soon.

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

            // parsing the string values of card ranks into integers for use in conditinals just below.
            int cardValueCurrent = int.Parse(cardValueCurrentArrayString[0]);
            int cardValuePrevious = int.Parse(cardValuePreviousArrayString[0]);

            int points = doublePoints ? 20 : 10;

            // scoring system
            if (cardValueCurrent > cardValuePrevious)
            {
                score += points;
                if (score >= 100)
                {
                    textBox.Text = score.ToString();
                    textBox6.Text = guesses.ToString();
                    MessageBox.Show("Congratulations! It took you " + guesses + " guesses to win.");
                    //attempting to store the current number of guesses into highscore to add to statistics.xaml table
                    highScore = guesses;
                    //limits number of scores in statistics table to 10.
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
                    //only used to make sure high scores are being added,sorted and limited - (10) - to high score array
                    //this will be removed.
                    for (int a = 0; a < highScoreArray.Count; a++)
                    {
                        MessageBox.Show(highScoreArray[a].ToString());
                    }
                    reset();
                }
                doublePoints = false;
            }
            else if (cardValueCurrent == cardValuePrevious)
            {
                MessageBox.Show("Double Points!");
                doublePoints = true;
                //when current and previous cards are equal in rank, no. of guesses remains same.
                guesses -= 1;
            }
            else
            {
                score -= points;
                doublePoints = false;
            }
            textBox6.Text = guesses.ToString();
            textBox.Text = score.ToString();
        }
        
        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            guesses += 1;
            index += 1;
            previndex += 1;

            if (index == textBoxList.Count)
            {
                index = 0;
            }

            if (previndex == textBoxList.Count)
            {
                previndex = 0;
            }

            initClick();

            string[] cardValueCurrentArrayString = textBoxList[index].Text.Split();
            string[] cardValuePreviousArrayString = textBoxList[previndex].Text.Split();

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

            int points = doublePoints ? 20 : 10;

            if (cardValueCurrent < cardValuePrevious)
            {
                score += points;
                if (score >= 100)
                {
                    textBox.Text = score.ToString();
                    textBox6.Text = guesses.ToString();
                    MessageBox.Show("Congratulations! It took you " + guesses + " guesses to win.");
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
                doublePoints = false;
            }
            else if (cardValueCurrent == cardValuePrevious)
            {
                MessageBox.Show("Double Points!");
                doublePoints = true;
                guesses -= 1;
            }
            else
            {
                score -= points;
                doublePoints = false;
            }
            textBox6.Text = guesses.ToString();
            textBox.Text = score.ToString();
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
