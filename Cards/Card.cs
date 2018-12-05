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
            Flipped = false;
            this.Size = new System.Drawing.Size(90, 138);
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
        public void EnableSelecting()
        {
            base.Click += new EventHandler(NewClick);
        }
        private void NewClick(object sender, EventArgs e)
        {
            
            if (!Selected)
            {
                this.BorderStyle = BorderStyle.Fixed3D;
                this.selected = true;
            }
            else
            {
                this.BorderStyle = BorderStyle.None;
                this.selected = false;
            }
           
        }

        public string Value { get => value; set => this.value = value; }
        public Suits Color { get => color; set => color = value; }
        public bool Flipped { get => flipped; set => flipped = value; }
        public bool Selected { get => selected; set => selected = value; }

        public void Flip()
        {
            if (!Flipped)
            {
                this.ImageLocation = "./resources/" + Value + Color.ToString() + ".png";
                Flipped = true;
            }
            else
            {
                this.ImageLocation = back;
                Flipped = false;
            }
        }
    }
}
