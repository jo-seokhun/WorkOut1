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
            //client index 숫자에서 이름으로 바꿔주기
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

            listen = null;
            //client에서 send해주면 textbox1에 불러오기
            if (listen != null)
            {
                DialogResult ret = MessageBox.Show("현재 연결이 끊어집니다.\r\n계속 하시겠습니까?", "", MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  //현재 오픈되어있는 리스너 중지
                listen = null;
                threadServer2.Abort();
                if (threadRead2 != null && threadRead2.IsAlive) threadRead2.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(CPtoH);
            listen.Start();

            

            threadServer2 = new Thread(ServerProcess2);
            threadServer2.Start();

            threadRead2 = new Thread(ReadProcess2);

            
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

        void AddText2(string str) //문자열 str을 tbServer TextBox애 출력하는 함수
        {
            if (textBox1.InvokeRequired)     //대리호출이 필요한 상황입니까?
            {
                CBAddText cb = new CBAddText(AddText2);
                object[] obj = { str };
                Invoke(cb, obj);
            }
            else
            {
                textBox1.Text += str;
            }

        }

        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadServer2 = null;
        Thread threadRead = null;
        Thread threadRead2 = null;


        int CP1 = 9001;
        int CP2 = 9002;
        int CP3 = 9003;
        int CP4 = 9004;
        int CP5 = 9005;
        int CPtoH = 9006;

        private void Mnu1_Click(object sender, EventArgs e)
        {
            listen = null;
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
            listen = null;
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
            listen = null;
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
            listen = null;
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
            listen = null;
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

        void ServerProcess2()
        {
            while (true)
            {
                if (listen.Pending())
                {
                    tcp = listen.AcceptTcpClient();
                    threadRead2.Start();
                    break;
                }
                Thread.Sleep(100);
            }
        }
        void ReadProcess2()
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);      //Read byte
                    AddText2(Encoding.Default.GetString(bArr, 0, n));

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
            if (threadServer2 != null) threadServer2.Abort();
            if (threadRead2 != null) threadRead2.Abort();
            if (listen != null) listen.Stop();

        }

        private void ShowDataGrid_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                //Encoding enc;
                //enc = Encoding.UTF8;


                string str = textBox1.Text;

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
            else if(textBox1.Text=="")
            {
                MessageBox.Show("DataGrid로 만들어줄 Data가 없습니다.");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MnuHelp_Click(object sender, EventArgs e)
        {
            string str = "Training FeedBack App에 오신걸 환영합니다!\r\n현재 모드는 Header Mode입니다.\r\n\r\n< 고객과의 채팅 >\r\n1.상단메뉴 Chatting 클릭\r\n2. 하단 우측 텍스트박스에 정보 입력\r\n3.엔터키 누르기\r\n4. 상단 우측 텍스트박스에 채팅창 확인\r\n\r\n< 고객으로부터 전송받은 운동일지 확인 >\r\n1.고객이 운동일지 전송 시 좌측 하단 텍스트박스에 글자 생성됌\r\n2.상단 메뉴 DataGrid 형식으로 보기 클릭\r\n3.좌측 상단 DataGrid형식으로 고객의 운동일지 확인";
            MessageBox.Show(str, "도움말", MessageBoxButtons.OK);
        }
    }
}
