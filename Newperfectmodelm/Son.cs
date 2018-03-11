using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newperfectmodelm
{
    public class Son
    {
        SoundEffectInstance Sound;

        

        public float Pitch
        {
            get { return Sound.Pitch; }
            set { Sound.Pitch = value; }
        }

        public float Pan
        {
            get { return Sound.Pan; }
            set { Sound.Pan = value; }
        }

        public float Volume
        {
            get { return Sound.Volume; }
            set { Sound.Volume = value; }
        }

        public SoundState State
        {
            get { return Sound.State; }
        }

        public Son(SoundEffect se)
        {
            Sound = se.CreateInstance();
        }

        public void Play()
        {
            Sound.Play();
        }

        public void Pause()
        {
            Sound.Pause();
        }

        public void Stop()
        {
            Sound.Stop();
        }
    }
}
