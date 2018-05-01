using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Graphics
{
    public class Animation
    {
        public int CurrentFrame { get; set; }

        public int FrameCount { get; private set; }

        public float FrameSpeed { get; set; }

        public int FrameHeight { get { return Texture.Height; } }

        public int FrameWidth { get { return Texture.Width / FrameCount; } }

        public bool IsLooping { get; set; }

        public bool IsOneShot { get; private set; }

        public Texture2D Texture { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="texture">Texture de l'animation</param>
        /// <param name="frameCount">Nombre de Frame</param>
        /// <param name="delay"></param>Millisecondes entre chaque frames</param>
        /// <param name="isOneShot">true si l'animation ne se joue qu'une fois, false sinon</param>
        public Animation(Texture2D texture, int frameCount, float delay, bool isOneShot)
        {
            Texture = texture;
            FrameCount = frameCount;
            IsLooping = true;
            IsOneShot = isOneShot;

            FrameSpeed = delay;
        }
    }
}
