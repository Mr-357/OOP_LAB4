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
    public enum Combos
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
       
        private Combos combo;
        public Standard(IModel model, IView view)
        {
            this.Model = model;
            this.View = view;
            model.EnableSelect();
        }
       

        public void bet()
        {
          //  throw new NotImplementedException();
        }

        public override void calculate()
        {
            points = this.View.Bet * (int)combo;
            comboName = combo.ToString();
        }

        public override void checkCombos()
        {
            if (StraightFlush())
            {
                combo =Combos.Straight_Flush;
                return;
            }
            if (FourOfAKind())
             {
                 combo = Combos.Four_of_a_kind;
                 return;
             }
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

        public override void deal()
        {
            setCards();
            swapped = false;
        }

        





        public override void  swap()
        {
            if (!swapped)
            {
                int count = 0;
                List<Card> toSwap = new List<Card>();
                foreach (Card c in this.View.Cards)
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
                foreach (Card c in this.View.Cards)
                {
                    copy.Add(c);
                }
                foreach (Card c in toSwap)
                {
                    copy.Remove(c);
                }
                toSwap = this.Model.swap(toSwap);
                foreach (Card c in toSwap)
                {
                    copy.Add(c);
                }
                this.View.Cards = copy;
                foreach (Card c in this.View.Cards)
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
