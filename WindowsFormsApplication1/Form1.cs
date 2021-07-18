using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        TcpClient clientSocket = new TcpClient();
        NetworkStream stream = default(NetworkStream);

        int exbtn = 0;
        int shorbtn_orperson = 0;
        int shorbtn_mafia = 0;

        public string user = null;
        Button[] btnArr;
        Button[] btnArr2;
        string cl = "";

        Dictionary<int, string> clientNickname = new Dictionary<int, string>();

        public int clientNum = 1;



        public Dictionary<int, int> RoleDic = new Dictionary<int, int>();


        //
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        int num4 = 0;

        int roleNumber = 0;


        private int daytime;

        int m = 0;

        Random r = new Random();
        int[] role_assign = new int[4];
        bool rnd_check = true;
        int i = 0;


        int mafiaButton = 0;
        


        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            btnArr = new Button[4];
            btnArr[0] = client1;
            btnArr[1] = client2;
            btnArr[2] = client3;
            btnArr[3] = client4;

            btnArr2 = new Button[4];
            btnArr2[0]= NightButton1;
            btnArr2[1] = NightButton2;
            btnArr2[2] = NightButton3;
            btnArr2[3] = NightButton4;

            sp();

            daytime = 30;
        }
        private void sp()
        {

            SoundPlayer sp = new SoundPlayer();
            sp.Stream = Properties.Resources.BGM;
            sp.Play();
        }





        private void joinbutton_Click(object sender, EventArgs e)  
        {

            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Enabled = false;
            }

            loginpanel.Visible = false;

            clientSocket.Connect("127.0.0.1", 9990); 
            stream = clientSocket.GetStream();

            

            byte[] buffer = new byte[1024]; 
            int bytes = stream.Read(buffer, 0, buffer.Length);
            user = Encoding.Unicode.GetString(buffer, 0, bytes);
            user = user.Substring(0, user.IndexOf("$"));



            if (user == "참가자1")
            {
                roleNumber = 1;
                timeShorten_mf.Visible = false;
            }

            else if (user == "참가자2")
            {
                roleNumber = 2;
                timeExtend.Visible = false;
                timeShorten.Visible = false;
                timeShorten_mf.Visible = false;
            }
            else if (user == "참가자3")
            {
                roleNumber = 3;
                timeExtend.Visible = false;
                timeShorten.Visible = false;
                timeShorten_mf.Visible = false;

            }
            else
            {
                roleNumber = 4;
                timeExtend.Visible = false;
                timeShorten.Visible = false;
            }

            if (roleNumber == 1)
            {
                MyChatBox.Invoke(new Action(() => MyChatBox.AppendText("당신은 일반시민 입니다.\n")));
            }
            else if (roleNumber == 2)
            {
                MyChatBox.Invoke(new Action(() => MyChatBox.AppendText("당신은 의사 입니다.\n")));
            }
            else if (roleNumber == 3)
            {
                MyChatBox.Invoke(new Action(() => MyChatBox.AppendText("당신은 경찰 입니다.\n")));
            }
            else
            {
                MyChatBox.Invoke(new Action(() => MyChatBox.AppendText("당신은 마피아 입니다.\n")));
            }


            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Visible = false;
            }

            Thread t = new Thread(getMessage);
            t.IsBackground = true;
            t.Start();

        }
       

        private void getMessage() 
        {
            while (true)
            {
                
                stream = clientSocket.GetStream();
                int size = clientSocket.ReceiveBufferSize;
                byte[] buffer = new byte[size];
                int bytes = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.Unicode.GetString(buffer, 0, bytes);


                if (message.Contains("Daytime!"))
                {
                    
                    textBoxDay.Invoke(new Action(() => {
                        string[] getTime = message.Split('!');
                        textBoxDay.Text = getTime[1];
                    }));

                    if(textBoxDay.Text =="0")
                    {
                        sendtext.Enabled = false;
                        sendbutton.Enabled = false;
                    }

                    
                }
                else if (message.Contains("EndDayTime!"))
                {
                    textBoxDay.Text = 0.ToString();

                    string[] getPerson = message.Split('!');

                    string getString = getPerson[1];

                    chattingbox.Invoke(new Action(() => chattingbox.AppendText(getString + "\n")));

                    if (user!="참가자1")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            btnArr2[i].Visible = true;
                        }
                        for (int i = 0; i < 4; i++)
                        {
                            btnArr2[i].Enabled = true;
                        }
                    }
                    

                    sendtext.Enabled = false;
                    sendbutton.Enabled = false;

                    for (int i = 0; i < 4; i++)
                    {
                        btnArr[i].Visible = false;
                    }
                    
                    if(user == "참가자2")
                    {
                        chattingbox.Invoke(new Action(() => chattingbox.AppendText( "살릴 사람을 선택해 주세요\n")));
                    }
                    else if(user == "참가자3")
                    {
                        chattingbox.Invoke(new Action(() => chattingbox.AppendText("조사할 사람을 선택해 주세요\n")));
                    }
                    else if (user == "참가자4")
                    {
                        chattingbox.Invoke(new Action(() => chattingbox.AppendText("죽일 사람을 선택해 주세요\n")));
                    }
                }
                
                else
                {
                    chattingbox.Invoke(new Action(() => chattingbox.AppendText(message + "\n")));
                    
                }

                if(message.Contains("stop!"))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        btnArr[i].Enabled = true;
                    }
                }
                
            }

        }

        private void NightAct()
        {
            
            byte[] buffer = new byte[1024]; 
            int bytes = stream.Read(buffer, 0, buffer.Length);
            string message = Encoding.Unicode.GetString(buffer, 0, bytes);
            

        }
        private void sendtext_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendbutton_Click_1(sender, e);
            }
        }



        private void sendbutton_Click_1(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.Unicode.GetBytes(sendtext.Text.ToString() + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            sendtext.Clear();
        }
        
        private void Client1_Click(object sender, EventArgs e)
        {
            choseClient(1);

        }

        private void Client2_Click(object sender, EventArgs e)
        {
            choseClient(2);

        }

        private void Client3_Click(object sender, EventArgs e)
        {
            choseClient(3);

        }

        private void Client4_Click(object sender, EventArgs e)
        {
            choseClient(4);

        }

        private void choseClient(int num) 
        {
            for (int i = 0; i < 4; i++)
            {
                btnArr[i].Enabled = false;
            }

            string ch = "chose!" + num;

            byte[] buffer = Encoding.Unicode.GetBytes(ch + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();

        }

        private void NightButton1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Visible = false;
            }
            num1++;

            string ch = "NightChoseperson!" + num1;

            byte[] buffer = Encoding.Unicode.GetBytes(ch + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void NightButton2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Visible = false;
            }
            num2++;

            string ch = "NightChoseperson!" + num2;

            byte[] buffer = Encoding.Unicode.GetBytes(ch + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void NightButton3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Visible = false;
            }
            num3++;

            string ch = "NightChoseperson!" + num3;

            byte[] buffer = Encoding.Unicode.GetBytes(ch + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void NightButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                btnArr2[i].Visible = false;
            }
            num4++;
            string ch = "NightChoseperson!" + num4;

            byte[] buffer = Encoding.Unicode.GetBytes(ch + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }


        private void timeExtend_Click_1(object sender, EventArgs e)// 연장 버튼
        {
            exbtn++;

            timeExtend.Enabled = false;

            string ex = "press!" + exbtn;

            byte[] buffer = Encoding.Unicode.GetBytes(ex + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();


        }
        private void timeShorten_Click(object sender, EventArgs e)
        {
            shorbtn_orperson++;

            timeShorten.Enabled = false;

            string sh_or = "press2!" + shorbtn_orperson;

            byte[] buffer = Encoding.Unicode.GetBytes(sh_or + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        
        private void timeShorten_mf_Click(object sender, EventArgs e)
        {
            shorbtn_mafia++;

            timeShorten_mf.Enabled = false;

            string sh_mf = "press3!" + shorbtn_mafia;

            byte[] buffer = Encoding.Unicode.GetBytes(sh_mf + "$");
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }
        
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loginpanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        
    }
}