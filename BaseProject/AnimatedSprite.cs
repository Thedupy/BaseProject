using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class AnimatedSprite : Sprite
    {
        public int frameWidth, frameHeight, frame, frameNumber;
        public float animationTimer, delay;
        public bool loop, inAnim, backTo;

        public Rectangle FrameBox
        {
            get { return new Rectangle(frame * frameWidth, 0, frameWidth, frameHeight); }
        }

        public new Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, frameWidth, frameHeight); }
        }

        public AnimatedSprite(Texture2D _texture, Vector2 _position, int _frameWidth, int _frameHeight, int _frameNumber)
            : base(_texture, _position)
        {
            frame = 0;
            frameWidth = _frameWidth;
            frameHeight = _frameHeight;
            frameNumber = _frameNumber;
        }

        public override void Update(float _time)
        {
            if (inAnim)
            {
                animationTimer += _time;
                if (animationTimer >= delay)
                {
                    Anim();
                }
            }
        }

        private void Anim()
        {
            if (frame == frameNumber - 1)
            {
                if (loop)
                    frame = 0;
                else
                {
                    if (backTo)
                        frame = 0;
                    inAnim = false;
                }
            }
            else
                frame++;

            animationTimer = 0;
        }

        public void Animate(bool _loop, float _delay, bool _backto)
        {
            loop = _loop;
            delay = _delay;
            backTo = _backto;
            Anim();
            inAnim = true;
        }

        public override void Draw(SpriteBatch _batch)
        {
            _batch.Draw(texture, position, FrameBox, Color.White);
        }
    }
}
