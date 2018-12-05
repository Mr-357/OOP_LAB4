using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public enum Suits
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
    public class Card : PictureBox
    {
        private string value;
        private Suits color;
        private bool flipped;
        private bool selected;
        private string back = "./resources/red_back.png";
        
        public Card(string value, Suits color)
        {
            this.Value = value;
            this.Color = color;
            this.ImageLocation = back;
            flipped = false;
            this.Size = new System.Drawing.Size(90, 138);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        private void EnableSelecting()
        {
            base.Click += new EventHandler(NewClick);
        }
        private void NewClick(object sender, EventArgs e)
        {
            this.selected = !this.selected;
            if (!selected)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                this.BorderStyle = BorderStyle.None;
            }
           
        }

        public string Value { get => value; set => this.value = value; }
        public Suits Color { get => color; set => color = value; }

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
