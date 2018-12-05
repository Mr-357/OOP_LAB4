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
    enum Hold_EmCombos
    {
        Straight_Flush = 150,
        Four_of_a_kind = 90,
        Big_dog=60,
        Flush=40,
        Straight=26,
        Little_dog=18,
        Bobtail_straight = 12,
        Three_of_a_kind = 8,
        Two_pair = 5,
        Pair=1,
        Lose=0
    }
    public class Texas : IController
    {
        private IModel model;
        private IView view;
        int mult;
        int multcount;
        Hold_EmCombos combo;
        public Texas(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
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
        //    throw new NotImplementedException();
        }
        private bool Pair()//
        {
            bool temp = false;
            int i = 0;
            while (!temp && i <5)
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
            if (multcount < 2)
                return false;

            int hit = 0;
            int count = 0;
            for(int i=0;i<this.view.Cards.Count;i++)
            {
                count = 0;
                foreach (Card card in this.view.Cards)
                {
                    if (this.view.Cards[i].Value == card.Value && card.Flipped && this.view.Cards[i].Flipped)
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
            if (multcount < 1)
                return false;
            bool ret = false;
            int i = 0;
            while (!ret && i < this.view.Cards.Count)
            {
                int count = 0;
                foreach (Card c  in this.view.Cards)
                {
                    if (c.Value == this.view.Cards[i].Value  && (c.Flipped && this.view.Cards[i].Flipped))
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
            if (multcount < 3)
                return false;
            bool ret = true;
            for (int i = 0; i < this.view.Cards.Count-1;i++)
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
            if (multcount < 3)
                return false;
            return false;
        }
        private bool StraightFlush() //
        {
            if (Straight() && Flush())
                return true;
            return false;

        }
        public void calculate()
        {
            if (StraightFlush())
            {
                combo = Hold_EmCombos.Straight_Flush;
                return;
            }
           /*if (FourOfAKind())
            {
                combo = Hold_EmCombos.Four_of_a_kind;
                return;
            }*/
           /* if (BigDog())
            {
                combo = Hold_EmCombos.Big_dog;
                return;
            }*/
            if (Flush())
            {
                combo = Hold_EmCombos.Flush;
                return;
            }
            if (Straight())
            {
                combo = Hold_EmCombos.Straight;
                return;
            }
          /*  if (LittleDog())
            {
                combo = Hold_EmCombos.Little_dog;
                return;
            }*/
          /*  if (BobTailStraight())
            {
                combo = Hold_EmCombos.Bobtail_straight;
                return;
            }*/
            if (ThreeOfAKind())
            {
                combo = Hold_EmCombos.Three_of_a_kind;
                return;
            }
            if (TwoPair())
            {
                combo = Hold_EmCombos.Two_pair;
                return;
            }
            if (Pair())
            {
                combo = Hold_EmCombos.Pair;
                return;
            }
            else
            {
                combo = Hold_EmCombos.Lose;
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
            for (int i = 0; i < 2; i++)
            {
                Card card = model.draw();
                card.Flip();
                // card.Location = new System.Drawing.Point(5 + i * 20, 10);

                hand.Add(card);
            }
            for (int i = 2; i < 5; i++)
            {
                Card card = model.draw();
                hand.Add(card);
            }
            this.view.Cards = hand;
            multcount = 0;
        }

        public void reveal()
        {
            calculate();
            if (combo == Hold_EmCombos.Lose)
            {
                this.score -= this.view.Bet;
                MessageBox.Show("You lost " + this.view.Bet.ToString() + " points", "Flop", MessageBoxButtons.OK);
            }
            else
            {
                int add= this.view.Bet * mult * (int)combo;
                this.score += add;
                MessageBox.Show("You won " + add + " points with a \r\n "+this.combo.ToString(), "Win", MessageBoxButtons.OK);
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
        }

        public void stop()
        {
            MessageBox.Show("Your score: " + this.view.Score, "Game Over!", MessageBoxButtons.OK);
            view.SetStartingPoints();
            start();
        }

        public void swap()
        {
            if (multcount == 0)
            {
                mult = 2;
           
                this.view.Cards[multcount + 2].Flip();
                multcount++;
                return;
            }
            if (multcount == 1)
            {
                mult = 1;
                this.view.Cards[multcount + 2].Flip();
                multcount++;
                score = score - this.view.Bet;
                return;
            }
            if (multcount == 2)
            {
                mult = 1;
                this.view.Cards[multcount + 2].Flip();
                multcount++;
                score = score - 2 * this.view.Bet;
                return;
            }
            else
            {
                MessageBox.Show("You opened all CCs", "Error", MessageBoxButtons.OK);
                return;
            }
        }
    }
}
