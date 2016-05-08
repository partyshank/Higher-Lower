using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        Random rand = new Random();
        Card card = new Card();
        Card prevCard = new Card();
        // list of textboxes in order to index them and cycle through upon click event.
        List<Image> imageBoxList = new List<Image>();
        List<TextBlock> cardIndicatorList = new List<TextBlock>();

        int score = 0;
        int guesses = 0;
        //index and previous index for textbox list when adding styling.
        int index = 0;
        int previndex = -1;
        bool doublePoints = false;
        int highscore = 0;
        public List<int> highscoreList = new List<int>();

        public Game()
        {
            InitializeComponent();
        }
        
        private void Game_Loaded(object sender, RoutedEventArgs e)
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\philip\Documents\Visual Studio 2015\Projects\Higher_Lower\Higher_Lower\highscore.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    highscoreList.Add(int.Parse(line));
                }
            }

            // generates a random initial card to start the game upon window load.
            addImageBox();
            addCardIndicator();
            card.Value = (cardValue)rand.Next(1, 14);
            card.Suit = (cardSuit)rand.Next(0, 4);
            imageBoxList[0].Source = card.getImage(card);
            cardIndicatorList[0].Text = "^";
            prevCard.Value = card.Value;
            prevCard.Suit = prevCard.Suit;
        }

        private List<Image> addImageBox()
        {
            imageBoxList.Add(image1);
            imageBoxList.Add(image2);
            imageBoxList.Add(image3);
            imageBoxList.Add(image4);
            imageBoxList.Add(image5);

            return imageBoxList;
        }

        private List<TextBlock> addCardIndicator()
        {
            cardIndicatorList.Add(textBlock1);
            cardIndicatorList.Add(textBlock2);
            cardIndicatorList.Add(textBlock3);
            cardIndicatorList.Add(textBlock4);
            cardIndicatorList.Add(textBlock5);

            return cardIndicatorList;
        }

        //sets text content and style for current index of imageBoxList
        private void initClick()
        {
            card.Value = (cardValue)rand.Next(1, 14);
            card.Suit = (cardSuit)rand.Next(0, 4);
            imageBoxList[index].Source = card.getImage(card);
            cardIndicatorList[index].Text = "^";
            cardIndicatorList[previndex].Text = null;
        }

        //upon completion of game, resets all back to intial state to start new game.
        private void reset()
        {
            for (int k = 0; k < imageBoxList.Count; k++)
            {
                imageBoxList[k].Source = null;
                cardIndicatorList[k].Text = null;
            }
            score = 0;
            guesses = 0;
            index = 0;
            previndex = -1;
            imageBoxList[0].Source = card.getImage(card);
            cardIndicatorList[0].Text = "^";

        }

        private void Higher_Click(object sender, RoutedEventArgs e)
        {
            guesses++;
            index++;
            previndex++;
            
            //in order to create a loop of the imageBoxList
            if (index == imageBoxList.Count)
            {
                index = 0;
            }

            if (previndex == imageBoxList.Count)
            {
                previndex = 0;
            }

            initClick();

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
                    highscore = guesses;
                    if (highscoreList.Count == 10)
                    {
                        if (highscoreList.Max() > highscore)
                        {
                            highscoreList.Remove(highscoreList.Max());
                            highscoreList.Add(highscore);
                        }
                    }
                    else if (highscoreList.Count < 10)
                    {
                        highscoreList.Add(highscore);
                    }
                    else
                    {
                        throw new ArgumentException("There are too many items in the highscore list");
                    }
                    highscoreList.Sort();
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\philip\Documents\Visual Studio 2015\Projects\Higher_Lower\Higher_Lower\highscore.txt"))
                    {
                        foreach (int score in highscoreList)
                        {
                            sw.WriteLine(score);
                        }
                    }
                    reset();
                }
                doublePoints = false;
            }
            else if (card.compare(card, prevCard) == 0)
            {
                MessageBox.Show("Double Points!");
                doublePoints = true;
                //when current and previous cards are equal in rank, no. of guesses remains same.
                //guesses is incremented prior to this scoring system hence need for "guesses -= 1"
                guesses -= 1;
            }
            else
            {
                score -= points;
                doublePoints = false;
            }
            textBox6.Text = guesses.ToString();
            textBox.Text = score.ToString();
            prevCard.Value = card.Value;
            prevCard.Suit = card.Suit;
        }
        
        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            guesses++;
            index++;
            previndex++;

            if (index == imageBoxList.Count)
            {
                index = 0;
            }

            if (previndex == imageBoxList.Count)
            {
                previndex = 0;
            }

            initClick();

            int points = doublePoints ? 20 : 10;

            if (card.compare(card, prevCard) == -1)
            {
                score += points;
                if (score >= 100)
                {
                    textBox.Text = score.ToString();
                    textBox6.Text = guesses.ToString();
                    MessageBox.Show("Congratulations! It took you " + guesses + " guesses to win.");
                    highscore = guesses;
                    if (highscoreList.Count == 10)
                    {
                        if (highscoreList.Max() > highscore)
                        {
                            highscoreList.Remove(highscoreList.Max());
                            highscoreList.Add(highscore);
                        }
                    }
                    else if (highscoreList.Count < 10)
                    {
                        highscoreList.Add(highscore);
                    }
                    else
                    {
                        throw new ArgumentException("There are too many items in the highscore list");
                    }
                    highscoreList.Sort();
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\philip\Documents\Visual Studio 2015\Projects\Higher_Lower\Higher_Lower\highscore.txt"))
                    {
                        foreach (int score in highscoreList)
                        {
                            sw.WriteLine(score);
                        }
                    }
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
            prevCard.Value = card.Value;
            prevCard.Suit = card.Suit;
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
