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
        Random rand = new Random();
        Card card = new Card();
        Card prevCard = new Card();
        // list of textboxes so i could index them and cycle through upon click event.
        List<TextBox> textBoxList = new List<TextBox>();

        int score = 0;
        int guesses = 0;
        //index and previous index for textbox arrays when adding styling.
        int index = 0;
        int previndex = -1;
        bool doublePoints = false;

        public Game()
        {
            InitializeComponent();
            // generates a random initial card to start the game upon window load.
            addTextBox();
            card.Value = (cardValue)rand.Next(1, 14);
            card.Suit = (cardSuit)rand.Next(0, 4);
            textBoxList[0].Text = card.ToString();
            textBoxList[0].FontWeight = FontWeights.Bold;
            textBoxList[0].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));
        }

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
            card.Value = (cardValue)rand.Next(1, 14);
            card.Suit = (cardSuit)rand.Next(0, 4);
            //using index will always add text to the second textbox on first click. increment index of textbox array on 
            //each click so appends text to the next textbox in array
            textBoxList[index].Text = card.ToString();
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
            textBoxList[0].Text = card.ToString();
            textBoxList[0].FontWeight = FontWeights.Bold;
            textBoxList[0].Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2E00"));

        }

        // higher_click and lower_click contain almost identical code. 
        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            guesses++;
            index++;
            previndex++;

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

            string[] prevCardArray = textBoxList[previndex].Text.Split();
            cardValue prevCardValue = (cardValue)Enum.Parse(typeof(cardValue), prevCardArray[0]);
            cardSuit prevCardSuit = (cardSuit)Enum.Parse(typeof(cardSuit), prevCardArray[2]);

            prevCard.Value = prevCardValue;
            prevCard.Suit = prevCardSuit;

            int points = doublePoints == true ? 20 : 10;

            // scoring system
            if (card.compare(card, prevCard) == 1)
            {
                score += points;
                if (score >= 100)
                {
                    textBox.Text = score.ToString();
                    textBox6.Text = guesses.ToString();
                    MessageBox.Show("Congratulations! It took you " + guesses + " guesses to win.");
                    reset();
                }
                doublePoints = false;
            }
            else if (card.compare(card, prevCard) == 0)
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
            guesses++;
            index++;
            previndex++;

            if (index == textBoxList.Count)
            {
                index = 0;
            }

            if (previndex == textBoxList.Count)
            {
                previndex = 0;
            }

            initClick();

            string[] prevCardArray = textBoxList[previndex].Text.Split();
            cardValue prevCardValue = (cardValue)Enum.Parse(typeof(cardValue), prevCardArray[0]);
            cardSuit prevCardSuit = (cardSuit)Enum.Parse(typeof(cardSuit), prevCardArray[2]);

            prevCard.Value = prevCardValue;
            prevCard.Suit = prevCardSuit;

            int points = doublePoints ? 20 : 10;

            if (card.compare(card, prevCard) == -1)
            {
                score += points;
                if (score >= 100)
                {
                    textBox.Text = score.ToString();
                    textBox6.Text = guesses.ToString();
                    MessageBox.Show("Congratulations! It took you " + guesses + " guesses to win.");
                    reset();
                }
                doublePoints = false;
            }
            else if (card.compare(card, prevCard) == 0)
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
