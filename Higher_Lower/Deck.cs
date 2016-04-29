using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Higher_Lower
{
    public class Deck
    {
        int[] cardArray = new int[52];
        
        public void deck()
        {
            for (int i = 0; i < 52; i++)
            {
                cardArray[i] = i;
            }
        }

        public void random()
        {
            Random rand = new Random();
            int num = 0;
            num = rand.Next(0,51);
        }

      /* public int getCard()
        {

        }*/

        public string result()
        {
            int a = 8;
            int b = 2;
            string result;

            if (a > b)
            {
                result = "add";
                return result;
            }
            else if (a == b)
            {
                result = "equal";
                return result;
            }
            else
            {
                result = "sub";
                return result;
            }
        }
    }
}
