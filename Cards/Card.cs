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
    public class Card : PictureBox
    {
        private string value;
        private Color color;
        private bool flipped;
        private string back = "./resources/red_back.png";
        public Card(string value, Color color)
        {
            this.value = value;
            this.color = color;
            this.ImageLocation = back;
            flipped = false;
        }
        public void Flip()
        {
            if (!flipped)
            {
                this.ImageLocation = "./resources/" + value + color.ToString() + ".png";
                flipped = true;
            }
            else
            {
                this.ImageLocation = back;
                flipped = false;
            }
        }
    }
}
