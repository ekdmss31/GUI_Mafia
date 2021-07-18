using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    class Police : Citizen,INightAct
    {
        Mafia mafia = new Mafia();
        Random rnd = new Random();
        
        int point = 0;

        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }
        
        public string SetRole ()
        {
            role = 3.ToString();
            return role;
        }
        public override int OptainTheVote()
        {
            this.vote = 1;
            return vote;
        }

        public int LuckyMan()
        {
            if (rnd.Next(1, 21) == 1)
            {
                this.life += 1;
            }
            return life;
        }
        public int SetPoint (int pointing) 
        {
            point = pointing;
            return point;
        }
        public int NightAct()
        {
            if(point == 4)
            {
                return 1;
                
            }
            else
            {
                return 0;
                
            }
        }
        public override int GettingShot()
        {
            int bullet = mafia.nightAct; 

            life = life - bullet;

            if (life==2)
            {
                MessageBox.Show("당신은 입고 있던 방탄조끼 덕에 죽지 않았습니다.");
            }
            return life;

        }
    }
}
