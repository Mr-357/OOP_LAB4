using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cards;

namespace MVC
{
    public interface IModel
    {
        void init();
        Card draw();
        List<Card> swap(List<Card> toSwap);
        void refresh();
        int cardsleft
        {
            get;
        }
        void EnableSelect();
    }
}
