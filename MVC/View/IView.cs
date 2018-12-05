using Cards;
using MVC.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.View
{
    public interface IView
    {
        string Score
        {
            get;
            set;
        }
        int Bet
        {
            get;
            set;
        }
        List<Card> Cards
        {
            get;
            set;
        }
        void AddListener(IController controller);
        void SetStartingPoints();
    }
}
