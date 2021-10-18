﻿using System;
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
using Excel = Microsoft.Office.Interop.Excel;

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

            //datagrid에 지금까지 운동했던 내용을 보여줌
            Encoding enc;
            enc = Encoding.UTF8;

            byte[] barrOrg = File.ReadAllBytes(address);
            byte[] barr = Encoding.Convert(enc, Encoding.Default, barrOrg);
            string str = Encoding.Default.GetString(barr);

            string[] sarr = str.Split('\n');                //줄 별로 array만듬
            string[] sa1 = sarr[0].Trim().Split(',');       //줄 안에서 ,단위로 나눔

            for (int i = 0; i < sa1.Length; i++)
            {
                dbGrid.Columns.Add(sa1[i], sa1[i]);
            }
            for (int j = 1; j < sarr.Length; j++)
            {
                sa1 = sarr[j].Trim().Split(',');
                dbGrid.Rows.Add(sa1);
            }
        }

        

        SqlConnection sqlConn = new SqlConnection();    //Application Program과 DB를 연결시켜주는 도로 
        SqlCommand sqlCmd = new SqlCommand();           //그 도로를 타고 가는 자동차
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";

        string path = "C:\\Users\\조석훈\\source\\repos\\C#\\workoutprogram.csv";
        string address = "C:\\Users\\조석훈\\source\\repos\\C#\\workoutprogram.csv" ;




        /// <summary>
        /// <calculation 함수>
        /// 클릭 이벤트를 실행할 때 
        /// frmset, frminfo를 실행시키고 값을 받아와서
        /// str에 값을 넣어준다.
        /// </summary>
        public string calculation(string ExerType)
        {
            string str = "";
            try
            {
                int sets = 0;
                int set = 0;
                int[] weight = new int[512];
                int[] rep = new int[512];
                int[] trep = new int[512];
                int[] volume = new int[512];
                int[] Volume = new int[512];

                frmSet f3 = new frmSet(sets);
                if (f3.ShowDialog() == DialogResult.OK)
                {
                    set = int.Parse(f3.textBox1.Text);

                }
                frmInfo f2 = new frmInfo(10, 5);
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
                        if(textBox1.Text=="")
                        {
                            textBox1.Text += $"DATE,DAY,TYPE,SETS,WEIGHT,REPS,Total Reps,Volume\r\n";
                        }
                    }
                    
                    volume[i] = rep[i] * weight[i];
                    for (int j = 0; j < i + 1; j++)
                    {
                        trep[i] += rep[j];
                        Volume[i] += volume[j];
                    }
                    textBox1.Text += $"{f2.tbBoxDate.Text},{f2.tbBoxDoW.Text},{ExerType},{i + 1},{weight[i]}kg,{rep[i]},{trep[i]},{Volume[i]}kg \r\n";


                }
                //textBox1.Text += $"\r\n";

                str = textBox1.Text;
                return str;

            }
            catch
            {
                if (MessageBox.Show("운동종목을 재설정 하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    frmInfo f1 = new frmInfo();
                    f1.ShowDialog();
                }
                return str;
            }
        }


        string SetText = "";

        private void MnuSohp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuSohp.Text);
        }
        private void MnuSarere_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuSarere.Text);
        }

        private void MnuRearDelt_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuRearDelt.Text);
        }

        private void MnuOhp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuOhp.Text);
        }

        private void MnuSquat_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuSquat.Text);
        }

        private void MnuLegExtention_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuLegExtention.Text);
        }

        private void MnuLegCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuLegCurl.Text);
        }
        private void MnuDumbelCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuDumbelCurl.Text);
        }

        private void MnuBarbelCurl_Click(object sender, EventArgs e)
        {
            SetText =  calculation(MnuBarbelCurl.Text);
        }
        private void MnuBenchpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuBenchpress.Text);
        }
        private void MnuDumbelpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDumbelpress.Text);
        }
        private void MnuInclinebenchpress_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuInclinebenchpress.Text);
        }
        private void MnuDips_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDips.Text);
        }
        private void MnuFly_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuFly.Text);
        }
        private void MnuPullUp_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuPullUp.Text);
        }
        private void MnuRatpulldown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuRatpulldown.Text);
        }
        private void Mnudumbelrow_Click(object sender, EventArgs e)
        {
            SetText = calculation(Mnudumbelrow.Text);
        }
        private void MnuRow_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuRow.Text);
        }
        private void MnuDeadlift_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuDeadlift.Text);
        }
        private void MnuBarbelrow_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuBarbelrow.Text);
        }
        private void MnuArmpulldown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuArmpulldown.Text);
        }
        private void MnuCablepushdown_Click(object sender, EventArgs e)
        {
            SetText = calculation(MnuCablepushdown.Text);
        }



        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");

            File.AppendAllText(address, SetText,Encoding.UTF8);
        }





        private void btnOk_Click(object sender, EventArgs e)
        {
            //btnOk.DialogResult = DialogResult.OK;
        }
        private void bicepsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string day = dateTimePicker1.Value.ToString("yyyy.MM.dd");
            
            

        }

    }
}
