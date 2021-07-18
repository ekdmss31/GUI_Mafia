using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    abstract class Human
    {
        public int a = 0;
        public int b = 0;
        public int c = 0;
        public int d = 0;

        public int[] arr ;
        public int rnd_check = 1;
        public int i = 0;
        public int num = 0;
        public int vote = 1;
        

        public int result = 0;
        public int Agree = 0;
        public int Disagree = 0;

        abstract public void DeathByDay(string name);
       
        public int Pointing(int A, int B, int C, int D)
        {

            this.a = A; this.b = B; this.c = C; this.d = D;

            arr = new int[4] { a, b, c, d };

            for(int i = 0; i < 4; i++)
            {
                for(int j = i; j < 4; j++)
                {
                    if(arr[i]<arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
                
            }
            return arr[0];
        }

        public int AgreeDisagree(int agree , int disagree)
        {
            Agree = agree; disagree = Disagree;
            if(agree > disagree)
            {
                result = agree;
            }
            else if (agree == disagree)
            {
                result = 0;
            }
            else
            {
                result = disagree;
            }
            return result;
        }
    }
}
