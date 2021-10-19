namespace WorkOut
{
    partial class frmHeader
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
            this.clientIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu3 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Mnu5 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.tbChat2 = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbChat = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientIndexToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1138, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientIndexToolStripMenuItem
            // 
            this.clientIndexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mnu1,
            this.Mnu2,
            this.Mnu3,
            this.Mnu4,
            this.Mnu5});
            this.clientIndexToolStripMenuItem.Name = "clientIndexToolStripMenuItem";
            this.clientIndexToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.clientIndexToolStripMenuItem.Text = "Client Index";
            // 
            // Mnu1
            // 
            this.Mnu1.Name = "Mnu1";
            this.Mnu1.Size = new System.Drawing.Size(224, 26);
            this.Mnu1.Text = "1";
            this.Mnu1.Click += new System.EventHandler(this.Mnu1_Click);
            // 
            // Mnu2
            // 
            this.Mnu2.Name = "Mnu2";
            this.Mnu2.Size = new System.Drawing.Size(224, 26);
            this.Mnu2.Text = "2";
            this.Mnu2.Click += new System.EventHandler(this.Mnu2_Click);
            // 
            // Mnu3
            // 
            this.Mnu3.Name = "Mnu3";
            this.Mnu3.Size = new System.Drawing.Size(224, 26);
            this.Mnu3.Text = "3";
            this.Mnu3.Click += new System.EventHandler(this.Mnu3_Click);
            // 
            // Mnu4
            // 
            this.Mnu4.Name = "Mnu4";
            this.Mnu4.Size = new System.Drawing.Size(224, 26);
            this.Mnu4.Text = "4";
            this.Mnu4.Click += new System.EventHandler(this.Mnu4_Click);
            // 
            // Mnu5
            // 
            this.Mnu5.Name = "Mnu5";
            this.Mnu5.Size = new System.Drawing.Size(224, 26);
            this.Mnu5.Text = "5";
            this.Mnu5.Click += new System.EventHandler(this.Mnu5_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1138, 624);
            this.splitContainer1.SplitterDistance = 328;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dbGrid);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbChat2);
            this.splitContainer2.Size = new System.Drawing.Size(1138, 328);
            this.splitContainer2.SplitterDistance = 554;
            this.splitContainer2.SplitterWidth = 8;
            this.splitContainer2.TabIndex = 0;
            // 
            // dbGrid
            // 
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid.Location = new System.Drawing.Point(3, 3);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.RowHeadersWidth = 51;
            this.dbGrid.RowTemplate.Height = 27;
            this.dbGrid.Size = new System.Drawing.Size(548, 325);
            this.dbGrid.TabIndex = 0;
            // 
            // tbChat2
            // 
            this.tbChat2.Location = new System.Drawing.Point(3, 3);
            this.tbChat2.Multiline = true;
            this.tbChat2.Name = "tbChat2";
            this.tbChat2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChat2.Size = new System.Drawing.Size(570, 325);
            this.tbChat2.TabIndex = 1;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.textBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tbChat);
            this.splitContainer3.Size = new System.Drawing.Size(1138, 288);
            this.splitContainer3.SplitterDistance = 554;
            this.splitContainer3.SplitterWidth = 8;
            this.splitContainer3.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(551, 283);
            this.textBox1.TabIndex = 0;
            // 
            // tbChat
            // 
            this.tbChat.Location = new System.Drawing.Point(3, 3);
            this.tbChat.Multiline = true;
            this.tbChat.Name = "tbChat";
            this.tbChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbChat.Size = new System.Drawing.Size(570, 283);
            this.tbChat.TabIndex = 1;
            this.tbChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbChat_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(334, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(217, 25);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // frmHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 652);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmHeader";
            this.Text = "frmHeader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHeader_FormClosing);
            this.Load += new System.EventHandler(this.frmHeader_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dbGrid;
        private System.Windows.Forms.TextBox tbChat2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbChat;
        private System.Windows.Forms.ToolStripMenuItem clientIndexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Mnu1;
        private System.Windows.Forms.ToolStripMenuItem Mnu2;
        private System.Windows.Forms.ToolStripMenuItem Mnu3;
        private System.Windows.Forms.ToolStripMenuItem Mnu4;
        private System.Windows.Forms.ToolStripMenuItem Mnu5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}