using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cards;
using MVC;
using MVC.Controller;
using MVC.Model;
using MVC.View;

namespace Forms
{
    public partial class Form1 : Form, IView
    {
        private int startingScore;
        IController controller;
        public Form1()
        {
            InitializeComponent();
           // groupOne.Controls.Add(new Card("J", Suits.Clubs));
        }

        public string Score
        {
            get
            {
                return lblScore.Text;
            }
            set
            {
                lblScore.Text = value;
            }
        }
        public int Bet
        {
            get
            {
                return decimal.ToInt32(numBet.Value);
            }
            set
            {
            }
        }

        public List<Card> Cards
        {
            get
            {
                List<Card> ret = new List<Card>();
                foreach (Control c in groupOne.Controls)
                {
                    Card card = c as Card;
                    ret.Add(card);
                }
                return ret;
            }
            set
            {
                groupOne.Controls.Clear();
                for (int i=0;i<value.Count;i++)
                {
                    
                    groupOne.Controls.Add(value[i]);
                    groupOne.Controls[i].Location = new System.Drawing.Point(125 + i * 100, 10);
                }
            }
        }

        public void AddListener(IController controller)
        {
            this.controller = controller;
        }
        public void SetStartingPoints()
        {
            SetPoints f = new SetPoints();
            f.ShowDialog();
            DialogResult dlg = f.DialogResult;
            if (dlg == DialogResult.OK)
            {
                startingScore = f.Points;
            }
            lblScore.Text = startingScore.ToString();
        }
        private void frenchDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //texas
            SetStartingPoints();
            FrenchDeck deck = new FrenchDeck();
            deck.init();
            this.controller = new Texas(deck, this);
            controller.start();
            btnSwap.Text = "Reveal CC";
        }

        private void standardDeckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetStartingPoints();
            StandardDeck deck = new StandardDeck();
            deck.init();
            this.controller = new Texas(deck, this);
            controller.start();
            btnSwap.Text = "Reveal CC";
        }

        private void frenchDeckToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //standard
            SetStartingPoints();
            FrenchDeck deck = new FrenchDeck();
            deck.init();
            
            this.controller = new Standard(deck, this);
            controller.start();
            btnSwap.Text = "Swap Selected";
        }

        private void standardDeckToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetStartingPoints();
            FrenchDeck deck = new FrenchDeck();
            deck.init();
            this.controller = new Standard(deck, this);
            controller.start();
            btnSwap.Text = "Swap Selected";
        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            this.controller.bet();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            this.controller.swap();
        }

        private void btnReveal_Click(object sender, EventArgs e)
        {
            this.controller.reveal();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            this.controller.stop();
        }
    }
}
