using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Son
    {
        SoundEffectInstance sound;

        

        public float Pitch
        {
            get { return sound.Pitch; }
            set { sound.Pitch = value; }
        }

        public float Pan
        {
            get { return sound.Pan; }
            set { sound.Pan = value; }
        }

        public float Volume
        {
            get { return sound.Volume; }
            set { sound.Volume = value; }
        }

        public SoundState State
        {
            get { return sound.State; }
        }

        public Son(SoundEffect se)
        {
            sound = se.CreateInstance();
        }

        public void Play()
        {
            sound.Play();
        }

        public void Pause()
        {
            sound.Pause();
        }

        public void Stop()
        {
            sound.Stop();
        }
    }
}
