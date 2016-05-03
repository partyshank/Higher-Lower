using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_Lower
{
    public class Deck
    {

        //method to generate random card by suit and rank
        public string random()
        {
            //the pack of cards. suit(key), rank(values(array)). 
            Dictionary<string, string[]> newArray = new Dictionary<string, string[]>();
            string[] vals = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            newArray.Add("Clubs", vals);
            newArray.Add("Diamonds", vals);
            newArray.Add("Spades", vals);
            newArray.Add("Hearts", vals);

            Random rand = new Random();

            //transferring dictionary keys into an array for indexing purposes.
            string[] keysArray = newArray.Keys.ToArray();
            //generating a random key(suit) using .Next(int32) where the random key is between 0 and keysArray.Length
            int randKeyIndex = rand.Next(keysArray.Length);
            //using the random index to identify the suit to plug back into the dictionary
            string randKey = keysArray[randKeyIndex];
            // same as randKeyIndex, except for the index of the rank of card.
            int randCard = rand.Next(vals.Length);

            //identifies the random card and stores to be used in game for the next random card generated.
            string nextCard = newArray[randKey][randCard];

            //returns a string with random suit and rank of the next card. eg "Four of Diamonds"
            return String.Format("{0} of {1}", nextCard, randKey);
        }
    }
}
