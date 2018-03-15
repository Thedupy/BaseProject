using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{

    public static class TimerManager
    {
        public static List<Timer> Timers = new List<Timer>();

        public static void Update(float time)
        {
            for (int i = 0; i < Timers.Count; i++)
            {
                Timers[i].Update(time);
            }
            Timers.RemoveAll(k => k.Ended == true);
        }
    }

    public class Timer
    {
        OnEnd Action;
        float Time, Delay;
        bool Counted;
        int Count;

        public bool Ended;


        public Timer(float delay, OnEnd action, int count = 0)
        {
            Delay = delay;
            Action = action;
            if (count != 0)
            {
                Counted = true;
                Count = count;
            }
            else
                Counted = false;

            Ended = false;
        }


        public void Update(float time)
        {
            Time += time;
            if(Time >= Delay)
            {
                Action.Invoke();
                Time = 0;
                //if (!Counted)
                //    Ended = true;
                if(Counted)
                {
                    if (Count > 0)
                        Count--;
                    else
                        Ended = true;
                }
            }
        }

        public delegate void OnEnd();
    }
}
