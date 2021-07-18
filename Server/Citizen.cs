using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    abstract class Citizen:Human
    {
        public int life = 10;
        
        Mafia mafia = new Mafia();

        override public void DeathByDay(string name)
        {
            if(result == this.Agree)
            {
                MessageBox.Show(name + "는 투표로 죽었습니다.");
            }
        }

        virtual public int GettingShot()
        {
            int bullet = mafia.nightAct;

            life = life - bullet;

            return life;
        }

        public void DeathAtNight()
        {
            if(life <= 0)
            {
                MessageBox.Show("당신은 죽었습니다.");
            }
        }

        abstract public int OptainTheVote();
    }
}
