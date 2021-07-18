using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{

    public partial class serverform : Form
    {
        Mafia mafia = new Mafia();
        Doctor doctor = new Doctor();
        Police police = new Police();
        OrdinaryPerson op = new OrdinaryPerson();

        TcpListener server = null;
        TcpClient clientSocket = null;

        

        public Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        public Dictionary<int, string> intList = new Dictionary<int, string>();

        public string[] array = new string[4];
        Random r = new Random();


        int num = 0;
        int dayTime = 30; 
        int selectUserCnt = 0;
        int[] rule = new int[4];
        int[] m = new int[4];
        int exbtnCnt = 0;
        int shbtnCnt = 0;


        int voteMafia = 1;
        int voteDoctor = 1;
        int votePolice = 1;
        int voteOP = 1;

        int lifePolice = 1;
        int lifeDoctor = 1;
        int lifeOP = 1;
        
        
        public serverform()
        {
            InitializeComponent();
            
            Thread t = new Thread(initSocket);
            t.IsBackground = true;
            t.Start();

            police.SetRole();
            mafia.SetRole();
            doctor.SetRole();
            op.SetRole();
            

        }
        private void initSocket()
        {
            server = new TcpListener(IPAddress.Any, 9990);
            clientSocket = default(TcpClient); 
            server.Start();

            while (true)
            {
                try
                {
                    clientSocket = server.AcceptTcpClient();


                    NetworkStream stream = clientSocket.GetStream();

                    string[] arr = new string[4]
                    {
                        "참가자1","참가자2","참가자3","참가자4"
                    };

                    string getstring = arr[num];

                    byte[] buffer = Encoding.Unicode.GetBytes(getstring + "$");
                    stream.Write(buffer, 0, buffer.Length); 
                    stream.Flush();

                    List<string> arrList = new List<string>();
                    arrList.Add(getstring);



                    clientList.Add(clientSocket, getstring);
                    num++;


                    serverchattingbox.Invoke(new Action(() => serverchattingbox.AppendText(getstring + "님이 참가하셨습니다. \n")));

                    sendMessageAll(getstring + " 님이 참가하셨습니다.", "", false); 



                    if (num == 4) 
                    {
                        sendMessageAll("\n게임을 시작합니다.자유롭게 이야기하고 1분안에 마피아를 찾아주세요.", "", false);  

                        this.Invoke(new Action(() => timer1.Start()));
                                               
                    }
                    
    
                    HandleClient handleClient = new HandleClient();
                    handleClient.OnReceived += new HandleClient.MessageDisplayHandler(onReceived); 
                    handleClient.OnDisconnected += new HandleClient.DisconnectedHandler(onDisconnedted); 
                    handleClient.startClient(clientSocket, clientList);

                }

                catch (SocketException se)
                {
                    break;
                }
                catch (Exception se)
                {
                    break;
                }
            }
        }

        private void OptainTheVote()
        {
            voteDoctor += doctor.OptainTheVote();
            voteOP += op.OptainTheVote();
            votePolice += op.OptainTheVote();
        }
        private void OptainTheLife()
        {
            lifePolice += police.GettingShot();
            lifeOP = 2;
        }
        
        private void onDisconnedted(TcpClient clientSocket)
        {
            if (clientList.ContainsKey(clientSocket))
                clientList.Remove(clientSocket);
        }

        private void onReceived(string message, string userName) 
        {


            if (message.Contains("chose!"))
            {
                string[] c = message.Split('!');
                string num = c[1];
                int n = Convert.ToInt32(num);
                rule[n - 1]++;
                selectUserCnt++;



                if (selectUserCnt == 4)
                {
                    timer1.Enabled = false;
                    int max = rule[0];
                    int bestSelected = 1;


                    for (int i = 1; i < rule.Length; i++)
                    {
                        if (max < rule[i])
                        {
                            max = rule[i];
                            bestSelected = i + 1;

                        }
                        else if (max == rule[i])
                        {
                            bestSelected = 0;
                        }

                    }

                    if (bestSelected > 0)
                    {
                        sendMessageAll("---참가자" + bestSelected + "번이 투표에 의해 죽었습니다.---", "", false);
                        if (bestSelected == 4)//마피아가 첫번째로 죽이으면 게임 종료 알림 띄어주기
                        {
                            mafia.DeathByDay("알림");
                        }
                        else
                        {
                            if (bestSelected == 3)
                            {
                                sendMessageAll("---마피아로 경찰이 지목당했지만 방탄 조끼를 입고 있어서 죽지 않았습니다.---", "", false);
                                sendMessageAll("EndDayTime!" + "----이제 밤이 됩니다.----\n", "", false);
                            }

                        }

                    }
                    else
                    {
                        sendMessageAll("아무도 죽지 않았습니다", "", false);
                        sendMessageAll("EndDayTime!" + "----이제 밤이 됩니다.----", "", false);

                    }
                    

                }



            }else if (message.Contains("press!"))
            {
                string[] p = message.Split('!');
                int e = Convert.ToInt32(p[1]);
                exbtnCnt = e;

                int value = op.IncreaseTime();
                exbtnCnt = value;

                dayTime += exbtnCnt;

                sendMessageAll("---마피아 찾는 시간이" + exbtnCnt + "초 연장되었습니다.---", "", false);
                message = p[0];
            }
            else if (message.Contains("press!"))
            {
                string[] p = message.Split('!');
                int e = Convert.ToInt32(p[1]);
                exbtnCnt = e;

                int value = op.IncreaseTime();
                exbtnCnt = value;

                dayTime += exbtnCnt;

                sendMessageAll("---마피아 찾는 시간이" + exbtnCnt + "초 연장되었습니다.---", "", false);
                message = p[0];
            }
            else if (message.Contains("press2!")) 
            {
                string[] p2 = message.Split('!');
                int e2 = Convert.ToInt32(p2[1]);
                shbtnCnt = e2;

                int value = op.ReduceTime();
                shbtnCnt = value;

                dayTime -= shbtnCnt;

                sendMessageAll("---마피아 찾는 시간이" + shbtnCnt + "초 단축되었습니다.---", "", false);
                message = p2[0];
            }
            else if (message.Contains("press3!"))
            {
                string[] p3 = message.Split('!');
                int e3 = Convert.ToInt32(p3[1]);
                shbtnCnt = e3;

                int value = mafia.TimeShorten();
                shbtnCnt = value;

                dayTime += shbtnCnt;

                sendMessageAll("---마피아 찾는 시간이" + shbtnCnt + "초 단축되었습니다.---", "", false);
                message = p3[0];
            }
            else if (message.Contains("NightChoseperson!"))
            {
                string[] p = message.Split('!');
                int e = Convert.ToInt32(p[1]);
                exbtnCnt = e;

                int value = op.IncreaseTime();
                exbtnCnt = value;

                dayTime += exbtnCnt;

                
                message = p[0];
            }
            else
            {

                string displayMessage = userName + ":" + message;
                serverchattingbox.Invoke(new Action(() => serverchattingbox.AppendText(displayMessage + "\n")));
                sendMessageAll(message, userName, true);
            }

            

        }
        

        private void sendMessageAll(string message, string userName, bool flag)
        {
            foreach (var pair in clientList) 
            {

                TcpClient client = pair.Key as TcpClient;
                NetworkStream stream = client.GetStream();
                byte[] buffer = null;

                if (flag) 
                {
                    buffer = Encoding.Unicode.GetBytes(userName + " : " + message);
                }
                else 
                {
                    buffer = Encoding.Unicode.GetBytes(message);
                }
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();

            }
        }
        private void sendMessagePerson(string message, string userName, bool flag)
        {
            
            NetworkStream stream = null;
            byte[] buffer = new byte[1024];
            stream = clientSocket.GetStream();
            
            
            if (flag) 
            {
                buffer = Encoding.Unicode.GetBytes(userName+message);
            }
            else 
            {
                buffer = Encoding.Unicode.GetBytes(message);
            }
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        private void CountValue()
        {
            NetworkStream stream = null;
            byte[] buffer = new byte[1024];
            stream = clientSocket.GetStream();


        }

        private void Timer1_Tick(object sender, EventArgs e) 
        {
            
            sendMessageAll("Daytime!" + dayTime, "", false);

            dayTime--;
            

            if (dayTime <= 0)
            {
                timer1.Enabled = false;
                
            }
            
        }
        private int NightAct ()
        {
            if(doctor.nightAct == mafia.nightAct)
            {
                return 1;
            }
            if(police.SetPoint(num) != mafia.SetRole())
            {
                return 1;
            }
            else
            {
                return 0;
            }
            
        }
    }
}

