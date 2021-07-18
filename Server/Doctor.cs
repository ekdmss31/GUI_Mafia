using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Doctor:Citizen,INightAct
    {


        

        public int nightAct=0;
        
        int lifeMan = 0;

        private string role;

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        public string SetRole()
        {
            role = 2.ToString();
            return role;
        }

        public int SetSaveMan(int saveMan)
        {
            nightAct = saveMan;
            return nightAct;
        }
        public int NightAct() 
        {
            
            lifeMan += 1;
            return lifeMan;
        }
        public override int OptainTheVote()
        {
            Random rnd = new Random();
            if (rnd.Next(1, 16) == 1)
            {
                this.vote -= 1;
            }
            return vote;
        }

    }
}
