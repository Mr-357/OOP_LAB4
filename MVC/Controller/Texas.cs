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
        Pair=1
    }
    public class Texas : IController
    {
        private IModel model;
        private IView view;
        int mult;
        int multcount;
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

        public void calculate()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
