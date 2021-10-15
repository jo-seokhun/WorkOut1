using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myLibrary;
using static myLibrary.frminput;

namespace WorkOut
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        
        iniFile ini = new iniFile(".\\WorkOut.ini");

        private void form1_Load(object sender, EventArgs e)
        {
            int x = int.Parse(ini.GetString("Position", "LocationX", "0"));
            int y = int.Parse(ini.GetString("Position", "LocationY", "0"));
            Location = new Point(x, y);
        }

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");

        }

        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        string address = "C:\\Users\\조석훈\\source\\repos\\C#\\workoutprogram.csv";




        private void MnuSohp_Click(object sender, EventArgs e)
        {
            int sets = 0;
            int set = 0 ;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(sets);
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);
                
            }
            Form2 f2 = new Form2(10,5);
            for (int i =0; i<set; i++)
            {
                
                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for(int i=0;i<set;i++)
            {
                if(i==0)
                {
                textBox1.Text += $"S_OHP,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0]+rep[1];
                if (i == 2) trep[2] = rep[0]+rep[1]+rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2]+rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] ;
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] ;
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] ;
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8]+rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8]+rep[9]+rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i+1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";
                

            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);





            //string[] weight = null;
            //string[] Reps = null;
            //int[] total=null;

            //for (int j=0;j<set;j++)
            //{
            //    weight[j] = TbWeight.Text;
            //    Reps[j] = TbReps.Text;
            //    total[j] = (int.Parse(weight[j])) * (int.Parse(Reps[j]));
            //    textBox1.Text = $"{weight[j]}  {Reps[j]}  {total[j]} \r\n";
            //}




        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.DialogResult = DialogResult.OK;
        }

        private void MnuSarere_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"Sarere,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"RearDelt,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuOhp_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"OHP,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuSquat_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"SQUAT,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"LegExt,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"LegCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void bicepsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dumbelCurlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"DumCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }

        private void barbelCurlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sets = mylib.GetInput("Set : ");
            int set = 0;
            int[] weight = new int[512];
            int[] rep = new int[512];
            int[] trep = new int[512];      //total reps
            int[] volume = new int[512];
            int[] Volume = new int[512];

            Form3 f3 = new Form3(int.Parse(sets));
            if (f3.ShowDialog() == DialogResult.OK)
            {
                set = int.Parse(f3.textBox1.Text);

            }
            Form2 f2 = new Form2(10, 5);
            for (int i = 0; i < set; i++)
            {

                f2.ShowDialog();
                weight[i] = int.Parse(f2.TbBox1.Text);
                rep[i] = int.Parse(f2.TbBox2.Text);
            }
            for (int i = 0; i < set; i++)
            {
                if (i == 0)
                {
                    textBox1.Text += $"BarCurl,WEIGHT,REPS,Total Reps,Volume\r\n";

                }
                if (i == 0) trep[0] = rep[0];
                if (i == 1) trep[1] = rep[0] + rep[1];
                if (i == 2) trep[2] = rep[0] + rep[1] + rep[2];
                if (i == 3) trep[3] = rep[0] + rep[1] + rep[2] + rep[3];
                if (i == 4) trep[4] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4];
                if (i == 5) trep[5] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5];
                if (i == 6) trep[6] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6];
                if (i == 7) trep[7] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7];
                if (i == 8) trep[8] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8];
                if (i == 9) trep[9] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9];
                if (i == 10) trep[10] = rep[0] + rep[1] + rep[2] + rep[3] + rep[4] + rep[5] + rep[6] + rep[7] + rep[8] + rep[9] + rep[10];
                volume[i] = rep[i] * weight[i];
                if (i == 0) Volume[0] = volume[0];
                if (i == 1) Volume[1] = volume[0] + volume[1];
                if (i == 2) Volume[2] = volume[0] + volume[1] + volume[2];
                if (i == 3) Volume[3] = volume[0] + volume[1] + volume[2] + volume[3];
                if (i == 4) Volume[4] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4];
                if (i == 5) Volume[5] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5];
                if (i == 6) Volume[6] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6];
                if (i == 7) Volume[7] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7];
                if (i == 8) Volume[8] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8];
                if (i == 9) Volume[9] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9];
                if (i == 10) Volume[10] = volume[0] + volume[1] + volume[2] + volume[3] + volume[4] + volume[5] + volume[6] + volume[7] + volume[8] + volume[9] + volume[10];

                textBox1.Text += $"{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


            }
            textBox1.Text += $"\r\n";

            string str = textBox1.Text;
            //byte[] bArr = Encoding.Default.GetBytes(str);
            File.AppendAllText(address, str);
        }
    }
}
