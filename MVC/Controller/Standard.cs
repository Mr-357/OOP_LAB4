using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cards;
using MVC.View;

namespace MVC.Controller
{
    enum Combos
    {
        Straight_Flush = 100,
        Four_of_a_kind = 60,
        Big_bobtail = 40,
        Full_House = 24,
        Flush = 16,
        Straight = 12,
        Blaze =9,
        Three_of_a_kind = 6,
        Two_pair = 4,
        Pair = 2,
        Lose = 0
    }
    public class Standard : IController
    {
        private bool swapped = false;
        private IModel model;
        private IView view;
        private Combos combo;
        public Standard(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            model.EnableSelect();
        }
        public IModel Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }
        public int score
        {
            get
            {
                return int.Parse(this.view.Score);
            }
            set
            {
                this.view.Score = value.ToString();
            }
        }
        public IView View
        {
            get
            {
                return this.view;
            }
            set
            {
                this.view = value;
            }
        }

        public void bet()
        {
          //  throw new NotImplementedException();
        }
        #region combos
        private bool Pair()//
        {
            bool temp = false;
            int i = 0;
            while (!temp && i < 5)
            {
                int count = 0;
                foreach (Card c in this.view.Cards)
                {
                    if (c.Value == this.view.Cards[i].Value && c.Flipped && this.view.Cards[i].Flipped)
                        count++;
                }
                if (count == 2)
                    temp = true;
                i++;
            }
            return temp;
        }
        private bool TwoPair()//
        {

            int hit = 0;
            int count = 0;
            for (int i = 0; i < this.view.Cards.Count; i++)
            {
                count = 0;
                foreach (Card card in this.view.Cards)
                {
                    if (this.view.Cards[i].Value == card.Value)
                        hit++;
                    if (hit == 2)
                        count++;
                }
            }
            if (count == 4)
                return true;
            return false;
        }
        private bool ThreeOfAKind() // 
        {
          
               
            bool ret = false;
            int i = 0;
            while (!ret && i < this.view.Cards.Count)
            {
                int count = 0;
                foreach (Card c in this.view.Cards)
                {
                    if (c.Value == this.view.Cards[i].Value)
                        count++;
                }
                if (count == 3)
                    ret = true;
                i++;
            }
            return ret;
        }
        private bool Flush()//
        {
            
              
            bool ret = true;
            for (int i = 0; i < this.view.Cards.Count - 1; i++)
            {
                if (this.view.Cards[i].Color != this.view.Cards[i + 1].Color)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        private bool Straight()//
        {
            
            return false;
        }
        private bool StraightFlush() //
        {
            if (Straight() && Flush())
                return true;
            return false;

        }
        #endregion
        public void calculate()
        {
            if (StraightFlush())
            {
                combo =Combos.Straight_Flush;
                return;
            }
            /*if (FourOfAKind())
             {
                 combo = Combos.Four_of_a_kind;
                 return;
             }*/
            /* if (BigBobTail())
             {
                 combo =Combos.Big_bobtail;
                 return;
             }*/
            /*  if (FullHouse())
           {
               combo = Combos.Full_house;
               return;
           }*/
            if (Flush())
            {
                combo = Combos.Flush;
                return;
            }
            if (Straight())
            {
                combo = Combos.Straight;
                return;
            }
          
            /*  if (Blaze())
              {
                  combo = Combos.Blaze;
                  return;
              }*/
            if (ThreeOfAKind())
            {
                combo = Combos.Three_of_a_kind;
                return;
            }
            if (TwoPair())
            {
                combo = Combos.Two_pair;
                return;
            }
            if (Pair())
            {
                combo = Combos.Pair;
                return;
            }
            else{
                combo = Combos.Lose;
                return;
            }
        }

        public void deal()
        {
            if (model.cardsleft < 5)
            {
                model.refresh();
            }
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                Card card = model.draw();
               

                hand.Add(card);
            }
    
            this.view.Cards = hand;
            swapped = false;
        }

        public void reveal()
        {
            calculate();
            if (combo == Combos.Lose)
            {
                this.score -= this.view.Bet;
                MessageBox.Show("You lost " + this.view.Bet.ToString() + " points", "Flop", MessageBoxButtons.OK);
            }
            else
            {
                int add = this.view.Bet * (int)combo;
                this.score += add;
                MessageBox.Show("You won " + add + " points with a \r\n " + this.combo.ToString(), "Win", MessageBoxButtons.OK);
            }
            if (this.score <= 0)
            {
                stop();
                return;
            }
            deal();
        }

        public void start()
        {
         
            deal();
            foreach (Card c in this.view.Cards)
            {
                c.Flip();
            }
        }

        public void stop()
        {
            MessageBox.Show("Your score: " + this.view.Score, "Game Over!", MessageBoxButtons.OK);
            view.SetStartingPoints();
            start();
        }

        public void swap()
        {
            if (!swapped)
            {
                int count = 0;
                List<Card> toSwap = new List<Card>();
                foreach (Card c in this.view.Cards)
                {
                    if (c.Selected)
                    {
                        count++;
                        toSwap.Add(c);
                    }
                }
                if (count > 3)
                {
                    MessageBox.Show("You selected too many cards to swap", "Error", MessageBoxButtons.OK);
                    return;
                }
                List<Card> copy = new List<Card>();
                foreach (Card c in this.view.Cards)
                {
                    copy.Add(c);
                }
                foreach (Card c in toSwap)
                {
                    copy.Remove(c);
                }
                toSwap = this.model.swap(toSwap);
                foreach (Card c in toSwap)
                {
                    copy.Add(c);
                }
                this.view.Cards = copy;
                foreach (Card c in this.view.Cards)
                {
                    if(!c.Flipped)
                    c.Flip();
                }
                swapped = true;
            }
            else
            {
                MessageBox.Show("You alerady swapped cards this hand", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
