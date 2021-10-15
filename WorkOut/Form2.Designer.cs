namespace WorkOut
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnoutput = new System.Windows.Forms.Button();
            this.TbBox1 = new System.Windows.Forms.TextBox();
            this.TbBox2 = new System.Windows.Forms.TextBox();
            this.btninput = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "WEIGHT : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "REPS : ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnoutput
            // 
            this.btnoutput.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnoutput.Location = new System.Drawing.Point(201, 165);
            this.btnoutput.Name = "btnoutput";
            this.btnoutput.Size = new System.Drawing.Size(105, 35);
            this.btnoutput.TabIndex = 6;
            this.btnoutput.Text = "Ok";
            this.btnoutput.UseVisualStyleBackColor = true;
            this.btnoutput.Click += new System.EventHandler(this.btnoutput_Click);
            // 
            // TbBox1
            // 
            this.TbBox1.Location = new System.Drawing.Point(147, 64);
            this.TbBox1.Name = "TbBox1";
            this.TbBox1.Size = new System.Drawing.Size(93, 25);
            this.TbBox1.TabIndex = 7;
            this.TbBox1.Visible = false;
            // 
            // TbBox2
            // 
            this.TbBox2.Location = new System.Drawing.Point(147, 112);
            this.TbBox2.Name = "TbBox2";
            this.TbBox2.Size = new System.Drawing.Size(93, 25);
            this.TbBox2.TabIndex = 8;
            this.TbBox2.Visible = false;
            // 
            // btninput
            // 
            this.btninput.Location = new System.Drawing.Point(67, 167);
            this.btninput.Name = "btninput";
            this.btninput.Size = new System.Drawing.Size(108, 30);
            this.btninput.TabIndex = 9;
            this.btninput.Text = "입력";
            this.btninput.UseVisualStyleBackColor = true;
            this.btninput.Click += new System.EventHandler(this.btninput_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 205);
            this.Controls.Add(this.btninput);
            this.Controls.Add(this.TbBox2);
            this.Controls.Add(this.TbBox1);
            this.Controls.Add(this.btnoutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnoutput;
        private System.Windows.Forms.Button btninput;
        public System.Windows.Forms.TextBox TbBox1;
        public System.Windows.Forms.TextBox TbBox2;
    }
}