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
        SoundEffectInstance _sound;

        

        public float Pitch
        {
            get { return _sound.Pitch; }
            set { _sound.Pitch = value; }
        }

        public float Pan
        {
            get { return _sound.Pan; }
            set { _sound.Pan = value; }
        }

        public float Volume
        {
            get { return _sound.Volume; }
            set { _sound.Volume = value; }
        }

        public SoundState State
        {
            get { return _sound.State; }
        }

        public Son(SoundEffect se)
        {
            _sound = se.CreateInstance();
        }

        public void Play()
        {
            _sound.Play();
        }

        public void Pause()
        {
            _sound.Pause();
        }

        public void Stop()
        {
            _sound.Stop();
        }
    }
}
