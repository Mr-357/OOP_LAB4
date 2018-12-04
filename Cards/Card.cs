using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public enum Color
    {
        Spade,
        Heart,
        Club,
        Diamond
    }
    class Card : PictureBox
    {
        private int value;
        private Color color;

    }
}
