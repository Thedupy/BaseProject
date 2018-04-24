using System.Collections.Generic;

namespace BaseProject.Utility
{

    public static class TimerManager
    {
        public static List<Timer> Timers = new List<Timer>();

        public static void Update(float time)
        {
            foreach (var t in Timers)
            {
                t.Update(time);
            }

            Timers.RemoveAll(k => k.Ended == true);
        }
    }

    public class Timer
    {
        private OnEnd _action;
        private float _time, _delay;
        private bool _counted;
        private int _count;

        public bool Ended;


        public Timer(float delay, OnEnd action, int count = 0)
        {
            _delay = delay;
            _action = action;
            if (count != 0)
            {
                _counted = true;
                _count = count;
            }
            else
                _counted = false;

            Ended = false;
        }


        public void Update(float time)
        {
            _time += time;
            if (_time >= _delay)
            {
                _action.Invoke();
                _time = 0;
                //if (!Counted)
                //    Ended = true;
                if (_counted)
                {
                    if (_count > 0)
                        _count--;
                    else
                        Ended = true;
                }
            }
        }

        public delegate void OnEnd();
    }
}
