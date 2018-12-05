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
using MVC.View;

namespace Forms
{
    public partial class Form1 : Form, IView
    {
        private int startingScore;
        public Form1()
        {
            InitializeComponent();
        }

        public string Score
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public int Bet
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public List<Card> Cards
        {
            get;
            set;
        }

        public void AddListener(IController controller)
        {
            throw new NotImplementedException();
        }
    }
}
