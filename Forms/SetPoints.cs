using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class SetPoints : Form
    {
        private int points;
        public SetPoints()
        {
            InitializeComponent();
        }

        public int Points { get => points; set => points = value; }

        private void button1_Click(object sender, EventArgs e)
        {
            Points = decimal.ToInt32(numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
