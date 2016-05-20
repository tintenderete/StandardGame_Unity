using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BoardGameApi
{
    class Timer
    {
        
        public float timeLimit;
        public float count;

        public Timer(float timeLimit)
        {
            this.timeLimit = timeLimit;
           
        }

        public bool TimeOff()
        {
            float currentTime = count++;

            if (currentTime >= timeLimit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ResetTime()
        {
            this.count = 0;
        }
    }
}
