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
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
    class Card : PictureBox
    {
        private string value;
        private Color color;
        public Card(string value, Color color)
        {
            this.value = value;
            this.color = color;
            this.ImageLocation = "./resources/" + value + color.ToString() + ".png";
        }
    }
}
