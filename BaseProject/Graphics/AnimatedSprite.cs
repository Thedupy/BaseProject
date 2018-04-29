using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseProject.Utility;

namespace BaseProject.Graphics
{
    public class AnimatedSprite
    {
        protected Texture2D _texture;


        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;


        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;

        public AnimatedSprite(Texture2D texture)
        {
            _texture = texture;
        }

        public AnimatedSprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        
        

        public void Update(GameTime time)
        {
            Move();

            if (_animationManager != null)
            {
                SetAnimation();
                _animationManager.Update(time);
            }
            Position += Velocity;
        }

        private void SetAnimation()
        {
            if (Velocity.X > 0)
                _animationManager.Play(_animations["WalkRight"]);
            else if (Velocity.X < 0)
                _animationManager.Play(_animations["WalkLeft"]);
            else if (Velocity.Y > 0)
                _animationManager.Play(_animations["WalkDown"]);
            else if (Velocity.Y < 0)
                _animationManager.Play(_animations["WalkUp"]);
            else
                _animationManager.Stop();
        }

        public void Move()
        {
            if (Input.KeyPressed(Keys.Z, false))
                Velocity.Y = -Speed;
            else if (Input.KeyPressed(Keys.S, false))
                Velocity.Y = Speed;
            else
                Velocity.Y = 0;

            if (Input.KeyPressed(Keys.Q, false))
                Velocity.X = -Speed;
            else if (Input.KeyPressed(Keys.D, false))
                Velocity.X = Speed;
            else
                Velocity.X = 0;
        }

        public void Draw(SpriteBatch batch)
        {
            if (_texture != null)
                batch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(batch);
        }
    }
}
