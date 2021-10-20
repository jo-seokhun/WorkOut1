using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkOut
{
 

    public partial class frmSet : Form
    {
        int worksize;

        public frmSet(int size = 10)
        {
            InitializeComponent();
            worksize = size;

        }

        string str = "";
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(sender, e);

        }
    }
}
