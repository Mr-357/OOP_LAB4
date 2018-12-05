using Cards;
using MVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC.Controller
{
    public abstract class IController
    {
        protected string comboName;
        private IModel model;
        private IView view;
        protected int points;
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
        public void start()
        {
            deal();
        }
        public void setCards()
        {
            if (Model.cardsleft < 5)
            {
                Model.refresh();
            }
            List<Card> hand = new List<Card>();
            for (int i = 0; i < 5; i++)
            {
                Card card = Model.draw();
                card.Flip();
                // card.Location = new System.Drawing.Point(5 + i * 20, 10);

                hand.Add(card);
            }
          
            this.View.Cards = hand;
        }
        public void stop()
        {
            MessageBox.Show("Your score: " + this.View.Score, "Game Over!", MessageBoxButtons.OK);
            View.SetStartingPoints();
            start();
        }
        public abstract void checkCombos();
        public void reveal()
        {
            checkCombos();
            calculate();
            if(points<0)
            {
                this.score -= this.View.Bet;
                MessageBox.Show("You lost " + this.View.Bet.ToString() + " points", "Flop", MessageBoxButtons.OK);
            }
            else
            {
                
                this.score += points;
                MessageBox.Show("You won " + points + " points with a \r\n " + this.comboName, "Win", MessageBoxButtons.OK);
            }
            if (this.score <= 0)
            {
                stop();
                return;
            }
            deal();
        }
        public bool Pair()//
        {
            bool temp = false;
            int i = 0;
            while (!temp && i < 5)
            {
                int count = 0;
                foreach (Card c in this.View.Cards)
                {
                    if (c.Value == this.View.Cards[i].Value && c.Flipped && this.View.Cards[i].Flipped)
                        count++;
                }
                if (count == 2)
                    temp = true;
                i++;
            }
            return temp;
        }
        public bool TwoPair()//
        {

            int hit = 0;
            int count = 0;
            for (int i = 0; i < this.View.Cards.Count; i++)
            {
                count = 0;
                foreach (Card card in this.View.Cards)
                {
                    if (this.View.Cards[i].Value == card.Value && card.Flipped && this.View.Cards[i].Flipped)
                        hit++;
                    if (hit == 2)
                        count++;
                }
            }
            if (count == 4)
                return true;
            return false;
        }
        public bool ThreeOfAKind() // 
        {

            bool ret = false;
            int i = 0;
            while (!ret && i < this.View.Cards.Count)
            {
                int count = 0;
                foreach (Card c in this.View.Cards)
                {
                    if (c.Value == this.View.Cards[i].Value && (c.Flipped && this.View.Cards[i].Flipped))
                        count++;
                }
                if (count == 3)
                    ret = true;
                i++;
            }
            return ret;
        }
        public bool FourOfAKind()
        {
            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (view.Cards[i].Value == view.Cards[j].Value && (view.Cards[i].Flipped && view.Cards[j].Flipped))
                    {
                        count++;
                    }
                }
                if (count == 4)
                    return true;
            }
            return false;
        }
        public bool Flush()//
        {

            bool ret = true;
            for (int i = 0; i < this.View.Cards.Count - 1; i++)
            {
                if (this.View.Cards[i].Color != this.View.Cards[i + 1].Color && this.View.Cards[i].Flipped)
                {
                    ret = false;
                    break;
                }
            }
            return ret;
        }
        public bool Straight()//
        {
     
            return false;
        }
        public bool StraightFlush() //
        {
            if (Straight() && Flush())
                return true;
            return false;

        }
        public abstract void swap();
        public abstract void deal();
        public abstract void calculate();
        //public void bet();
    }
}
