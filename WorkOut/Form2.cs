using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary;

namespace WorkOut
{
    public partial class Form2 : Form
    {
        public delegate void FormSendDataHandler(string sendstring);

        public event FormSendDataHandler FormSendEvent;



        int Weight, Rep;


        public Form2(int weight = 10, int rep = 10)
        {
            InitializeComponent();
            Weight = weight;
            Rep = rep;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnoutput_Click(object sender, EventArgs e)
        {
            
        }

        private void btninput_Click(object sender, EventArgs e)
        {
            TbBox1.Visible = true;
            TbBox2.Visible = true;
        }
    }
}
