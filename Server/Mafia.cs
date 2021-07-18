using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class Mafia:Human, ITimeShorten, INightAct
    {
        
        Random rnd = new Random();

        public int nightAct = 0;

        private int life;

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        private int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        public int SetRole()
        {
            role = 4;
            return role;
        }
        public int TimeShorten()
        {
            int timeShorten = rnd.Next(1, 6);
            return timeShorten;
        }

        
        public int NightAct() 
        {
            life -=1;
            return life;

        }
        override public void DeathByDay(string name)
        {
            MessageBox.Show("마피아가 죽음으로 게임이 끝났습니다","알림");
        }
    }
}
