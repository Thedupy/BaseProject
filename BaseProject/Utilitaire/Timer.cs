using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{

    public static class TimerManager
    {
        public static List<Timer> timers = new List<Timer>();

        public static void Update(float _time)
        {
            for (int i = 0; i < timers.Count; i++)
            {
                timers[i].Update(_time);
            }
            timers.RemoveAll(k => k.ended == true);
        }
    }

    public class Timer
    {
        OnEnd action;
        float time, delay;
        bool counted;
        int count;

        public bool ended;


        public Timer(float _delay, OnEnd _action, int _count = 0)
        {
            this.delay = _delay;
            this.action = _action;
            if (_count != 0)
            {
                counted = true;
                this.count = _count;
            }
            else
                counted = false;

            ended = false;
        }


        public void Update(float _time)
        {
            this.time += _time;
            if(this.time >= delay)
            {
                action.Invoke();
                this.time = 0;
                //if (!Counted)
                //    Ended = true;
                if(counted)
                {
                    if (count > 0)
                        count--;
                    else
                        ended = true;
                }
            }
        }

        public delegate void OnEnd();
    }
}
