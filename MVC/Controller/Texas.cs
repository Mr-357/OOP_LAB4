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
    public enum Hold_EmCombos
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
        
        int mult;
        int multcount;
        Hold_EmCombos combo;
        public Texas(IModel model, IView view)
        {
            this.Model = model;
            this.View = view;
        }
       

        public void bet()
        {
        //    throw new NotImplementedException();
        }
        public override void calculate()
        {
            points = this.View.Bet * mult * (int)combo;
            comboName = combo.ToString();
        }
        public override void checkCombos()
        {
            if (StraightFlush())
            {
                combo = Hold_EmCombos.Straight_Flush;
                return;
            }
           if (FourOfAKind())
            {
                combo = Hold_EmCombos.Four_of_a_kind;
                return;
            }
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

        public override void deal()
        {
            setCards();
            for (int i = 2; i < 5; i++)
            {
                View.Cards[i].Flip();
            }
            
            multcount = 0;
        }

        public override void swap()
        {
            if (multcount == 0)
            {
                mult = 2;
           
                this.View.Cards[multcount + 2].Flip();
                multcount++;
                return;
            }
            if (multcount == 1)
            {
                mult = 1;
                this.View.Cards[multcount + 2].Flip();
                multcount++;
                score = score - this.View.Bet;
                return;
            }
            if (multcount == 2)
            {
                mult = 1;
                this.View.Cards[multcount + 2].Flip();
                multcount++;
                score = score - 2 * this.View.Bet;
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
