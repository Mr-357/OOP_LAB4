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
        private bool selected;
        private string back = "./resources/red_back.png";
        public Card(string value, Color color)
        {
            this.Value = value;
            this.Color = color;
            this.ImageLocation = back;
            flipped = false;
            this.Size = new System.Drawing.Size(40, 140);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public string Value { get => value; set => this.value = value; }
        public Color Color { get => color; set => color = value; }

        public void Flip()
        {
            if (!flipped)
            {
                this.ImageLocation = "./resources/" + Value + Color.ToString() + ".png";
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
