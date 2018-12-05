using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace MVC.Model
{
    public class StandardDeck : IModel
    {
        private List<Card> cards;

        public void refresh()
        {
            init();
        }
        public int cardsleft
        {
            get
            {

                return this.cards.Count;
            }
        }


        public Card draw()
        {
            Card ret = cards.Last();
            cards.Remove(ret);
            return ret;
        }

        public void init()
        {
            cards = new List<Card>();
            for (int i = 0; i < 4; i++)
            {
                int j = 2;

                cards.Add(new Card("A", (Suits)(i)));
               

                for (; j <= 10; j++)
                {
                    cards.Add(new Card(j.ToString(), (Suits)(i)));
                }
                cards.Add(new Card("J", (Suits)(i)));
                cards.Add(new Card("Q", (Suits)(i)));
                cards.Add(new Card("K", (Suits)(i)));
            }
            Shuffle();
        }

        public void Shuffle()
        {
            List<Card> tmp = new List<Card>();
            Random rng = new Random();
            while (cards.Count > 0)
            {
                Card rem = cards[rng.Next(0, cards.Count)];
                cards.Remove(rem);
                tmp.Add(rem);
            }
            cards = tmp;
        }

        public List<Card> swap(List<Card> toSwap)
        {
            int count = toSwap.Count;
            List<Card> tmp = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                Card card = cards.Last();
                cards.Remove(card);
                tmp.Add(card);
            }
            return tmp;
        }
    }
}
