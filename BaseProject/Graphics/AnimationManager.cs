using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Graphics
{
    public class AnimationManager
    {
        private bool OneShotPlaying;

        private Animation _animation, defaultAnimation;

        private float _timer;

        public Vector2 Position;

        public AnimationManager(Animation animation)
        {
            _animation = animation;
        }

        public void Play(Animation animation)
        {
            if (OneShotPlaying || _animation == animation)
                return;

            if (animation.IsOneShot)
            {
                OneShotPlaying = true;
                defaultAnimation = _animation;
            }

            _animation = animation;

            _animation.CurrentFrame = 0;

            _timer = 0;
        }

        public void Stop()
        {
            if (!OneShotPlaying)
            {
                _timer = 0f;

                _animation.CurrentFrame = 0;
            }
        }

        public void Pause()
        {
            _timer = 0f;

            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime time)
        {
            _timer += time.ElapsedGameTime.Milliseconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;

                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    if (OneShotPlaying)
                    {
                        OneShotPlaying = false;
                        _animation = defaultAnimation;
                    }
                    else
                    {
                        _animation.CurrentFrame = 0;
                    }
                }
            }
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(_animation.Texture,
                        Position,
                        new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                        0,
                                        _animation.FrameWidth,
                                        _animation.FrameHeight),
                        Color.White);
        }


    }
}
