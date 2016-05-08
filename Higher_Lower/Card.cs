using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_Lower
{
    public enum cardValue
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    public enum cardSuit
    {
        Clubs,
        Diamonds,
        Spades,
        Hearts
    }
    class Card
    {
        private cardValue value;
        private cardSuit suit;

        public cardValue Value
        {
            get { return value; }
            set { this.value = value; }
        }

        public cardSuit Suit
        {
            get { return suit; }
            set { suit = value; }
        }
        
        public Card()
        {

        }

        public int compare(Card currCard, Card prevCard)
        {
            if ((int)currCard.value > (int)prevCard.value)
            {
                return 1;
            }
            else if ((int)currCard.value == (int)prevCard.value)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} of {1}", value, suit);
        }

        public BitmapImage getImage(Card thisCard)
        {
            string filePath = @"C:\Users\philip\Documents\Visual Studio 2015\Projects\Higher_Lower\Higher_Lower\cardImages\";
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(filePath + thisCard.suit + (int)thisCard.value + ".bmp");
            image.EndInit();
            return image;
        }
    }
}
