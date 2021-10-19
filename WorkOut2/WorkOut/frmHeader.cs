using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkOut
{
    public partial class frmHeader : Form
    {
        public frmHeader()
        {
            InitializeComponent();
        }

        SqlDB sqldb = new SqlDB(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\조석훈\source\repos\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30");


        private void frmHeader_Load(object sender, EventArgs e)
        {
            int limit = 5;
            string[] name = new string[512];
            for (int i = 0; i < limit; i++)
            {
                name[i] = sqldb.GetString($"select name from workoutmem where code = {i + 2}");
            }
            Mnu1.Text = name[0];
            Mnu2.Text = name[1];
            Mnu3.Text = name[2];
            Mnu4.Text = name[3];
            Mnu5.Text = name[4];
            sqldb.Close();
        }

        delegate void CBAddText(string str);

        void AddText(string str) //문자열 str을 tbServer TextBox애 출력하는 함수
        {
            if (tbChat2.InvokeRequired)     //대리호출이 필요한 상황입니까?
            {
                CBAddText cb = new CBAddText(AddText);
                object[] obj = { str };
                Invoke(cb, obj);
            }
            else
            {
                tbChat2.Text += str;
            }
            
        }

        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;

        int CP1 = 9001;
        int CP2 = 9002;
        int CP3 = 9003;
        int CP4 = 9004;
        int CP5 = 9005;

        private void Mnu1_Click(object sender, EventArgs e)
        {
            Mnu1.Checked = true;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = false;

            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CP1);
            listen.Start();

            AddText($"Server port [{CP1}] started.\r\n");

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);

 
        }
        
        private void Mnu2_Click(object sender, EventArgs e)
        {
            Mnu2.Checked = true;
            Mnu1.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = false;

            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CP2);
            listen.Start();

            AddText($"Server port [{CP2}] started.\r\n");

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);


        }

        private void Mnu3_Click(object sender, EventArgs e)
        {
            Mnu3.Checked = true;
            Mnu2.Checked = false;
            Mnu1.Checked = false;
            Mnu4.Checked = false;
            Mnu5.Checked = false;

            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CP3);
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);

            AddText($"Server port [{CP3}] started.\r\n");
        }

        private void Mnu4_Click(object sender, EventArgs e)
        {
            Mnu4.Checked = true;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu1.Checked = false;
            Mnu5.Checked = false;

            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CP4);
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);

            AddText($"Server port [{CP4}] started.\r\n");
        }

        private void Mnu5_Click(object sender, EventArgs e)
        {
            Mnu5.Checked = true;
            Mnu2.Checked = false;
            Mnu3.Checked = false;
            Mnu4.Checked = false;
            Mnu1.Checked = false;

            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CP5);
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);

            AddText($"Server port [{CP5}] started.\r\n");
        }
        



        void ServerProcess()
        {
            while (true)
            {
                if (listen.Pending())
                {
                    tcp = listen.AcceptTcpClient();
                    threadRead.Start();
                    break;
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);      //Read byte
                    AddText(Encoding.Default.GetString(bArr, 0, n));

                }
                Thread.Sleep(100);
            }
        }



        

        private void tbChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tcp.Client !=null)
                {
                    string str; 
                    str = tbChat.Text;
                    str += "\r\n";
                    

                    tcp.Client.Send(Encoding.Default.GetBytes("[수신 : 관리자]" + str));
                    tbChat2.Text += "[송신 : 본인] " + str;
                    tbChat.Text = "";
                }

            }
        }




        private void frmHeader_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
            if (threadRead != null) threadRead.Abort();
            if (listen != null) listen.Stop();

        }
    }
}
