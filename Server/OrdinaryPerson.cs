using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class OrdinaryPerson:Citizen
    {
        Random rnd = new Random();

        private int role;

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        public int SetRole()
        {
            role = 1;
            return role;
        }
        override public int OptainTheVote()
        {
           if(rnd.Next(1,11)==1)
            {
                this.vote += 1;
            }
            return vote;
        }
        public int ReduceTime()
        {
            int timeShorten = rnd.Next(5, 8); 
            return timeShorten;
            
        }
        public int IncreaseTime()
        {
            int timeIncrease = rnd.Next(5, 8); 
            return timeIncrease;
        }
    }
}
