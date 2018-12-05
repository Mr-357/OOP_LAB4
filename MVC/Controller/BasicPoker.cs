using MVC.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Controller
{
    public class BasicPoker : IController
    {
        Combos combo;
        public BasicPoker(IModel model, IView view)
        {
            this.Model = model;
            this.View = view;
        }
        public override void calculate()
        {
            points = View.Bet * (int)combo;
            this.comboName = combo.ToString();
        }

        public override void checkCombos()
        {
            if (FourOfAKind())
            {
                combo = Combos.Four_of_a_kind;
            }
            if (ThreeOfAKind())
            {
                combo = Combos.Three_of_a_kind;
                return;
            }
         
            
            if (Pair())
            {
                combo = Combos.Pair;
                return;
            }
            else
            {
                combo = Combos.Lose;
                return;
            }
        }

        public override void deal()
        {
            setCards();
        }

        public override void swap()
        {
            return;
        }
    }
}
