namespace Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texasHoldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frenchDeckToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.standardDeckToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnBet = new System.Windows.Forms.Button();
            this.numBet = new System.Windows.Forms.NumericUpDown();
            this.btnSwap = new System.Windows.Forms.Button();
            this.btnReveal = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupOne = new System.Windows.Forms.GroupBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBet)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.texasHoldToolStripMenuItem,
            this.standardToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameToolStripMenuItem.Text = "New Game";
            // 
            // texasHoldToolStripMenuItem
            // 
            this.texasHoldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchDeckToolStripMenuItem,
            this.standardDeckToolStripMenuItem});
            this.texasHoldToolStripMenuItem.Name = "texasHoldToolStripMenuItem";
            this.texasHoldToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.texasHoldToolStripMenuItem.Text = "Texas Hold\'Em";
            // 
            // frenchDeckToolStripMenuItem
            // 
            this.frenchDeckToolStripMenuItem.Name = "frenchDeckToolStripMenuItem";
            this.frenchDeckToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.frenchDeckToolStripMenuItem.Text = "French Deck";
            this.frenchDeckToolStripMenuItem.Click += new System.EventHandler(this.frenchDeckToolStripMenuItem_Click);
            // 
            // standardDeckToolStripMenuItem
            // 
            this.standardDeckToolStripMenuItem.Name = "standardDeckToolStripMenuItem";
            this.standardDeckToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.standardDeckToolStripMenuItem.Text = "Standard Deck";
            this.standardDeckToolStripMenuItem.Click += new System.EventHandler(this.standardDeckToolStripMenuItem_Click);
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.frenchDeckToolStripMenuItem1,
            this.standardDeckToolStripMenuItem1});
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            // 
            // frenchDeckToolStripMenuItem1
            // 
            this.frenchDeckToolStripMenuItem1.Name = "frenchDeckToolStripMenuItem1";
            this.frenchDeckToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.frenchDeckToolStripMenuItem1.Text = "French Deck";
            this.frenchDeckToolStripMenuItem1.Click += new System.EventHandler(this.frenchDeckToolStripMenuItem1_Click);
            // 
            // standardDeckToolStripMenuItem1
            // 
            this.standardDeckToolStripMenuItem1.Name = "standardDeckToolStripMenuItem1";
            this.standardDeckToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.standardDeckToolStripMenuItem1.Text = "Standard Deck";
            this.standardDeckToolStripMenuItem1.Click += new System.EventHandler(this.standardDeckToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score:";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(72, 408);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(35, 13);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "label2";
            // 
            // btnBet
            // 
            this.btnBet.Location = new System.Drawing.Point(303, 403);
            this.btnBet.Name = "btnBet";
            this.btnBet.Size = new System.Drawing.Size(75, 23);
            this.btnBet.TabIndex = 4;
            this.btnBet.Text = "Bet";
            this.btnBet.UseVisualStyleBackColor = true;
            this.btnBet.Visible = false;
            this.btnBet.Click += new System.EventHandler(this.btnBet_Click);
            // 
            // numBet
            // 
            this.numBet.Location = new System.Drawing.Point(219, 406);
            this.numBet.Name = "numBet";
            this.numBet.Size = new System.Drawing.Size(63, 20);
            this.numBet.TabIndex = 5;
            // 
            // btnSwap
            // 
            this.btnSwap.Location = new System.Drawing.Point(384, 403);
            this.btnSwap.Name = "btnSwap";
            this.btnSwap.Size = new System.Drawing.Size(75, 23);
            this.btnSwap.TabIndex = 6;
            this.btnSwap.Text = "Swap";
            this.btnSwap.UseVisualStyleBackColor = true;
            this.btnSwap.Click += new System.EventHandler(this.btnSwap_Click);
            // 
            // btnReveal
            // 
            this.btnReveal.Location = new System.Drawing.Point(465, 403);
            this.btnReveal.Name = "btnReveal";
            this.btnReveal.Size = new System.Drawing.Size(75, 23);
            this.btnReveal.TabIndex = 7;
            this.btnReveal.Text = "Reveal";
            this.btnReveal.UseVisualStyleBackColor = true;
            this.btnReveal.Click += new System.EventHandler(this.btnReveal_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 408);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Bet ammount:";
            // 
            // groupOne
            // 
            this.groupOne.Location = new System.Drawing.Point(12, 120);
            this.groupOne.Name = "groupOne";
            this.groupOne.Size = new System.Drawing.Size(776, 150);
            this.groupOne.TabIndex = 9;
            this.groupOne.TabStop = false;
            this.groupOne.Text = "Hand";
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(546, 403);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 11;
            this.btnEnd.Text = "End Game";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(113)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.groupOne);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnReveal);
            this.Controls.Add(this.btnSwap);
            this.Controls.Add(this.numBet);
            this.Controls.Add(this.btnBet);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Poker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem texasHoldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frenchDeckToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem standardDeckToolStripMenuItem1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnBet;
        private System.Windows.Forms.NumericUpDown numBet;
        private System.Windows.Forms.Button btnSwap;
        private System.Windows.Forms.Button btnReveal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupOne;
        private System.Windows.Forms.Button btnEnd;
    }
}

