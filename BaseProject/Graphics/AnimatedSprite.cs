using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseProject.Utility;

namespace BaseProject.Graphics
{
    public enum Direction { Left, Right, Up, Down }
    public class AnimatedSprite : Entity
    {
        protected Texture2D _texture;

        private TweenPosition Tpos;

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;

        Direction direction;


        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                base.Position = value;

                if (_animationManager != null)
                    _animationManager.Position = _position;
            }
        }

        public float Speed = 1f;

        public Vector2 Velocity;

        public AnimatedSprite(Texture2D texture, Vector2 position) : base(position)
        {
            _texture = texture;
        }

        public AnimatedSprite(Dictionary<string, Animation> animations, Vector2 position) : base(position)
        {
            Position = position;
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);

            direction = Direction.Down;
            Tpos = new TweenPosition(this);
        }




        public void Update(GameTime time)
        {
            Tpos.Update(time.ElapsedGameTime.Milliseconds, ref _position);
            Move();

            SetAnimation();

            _animationManager.Update(time);

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

            if (Input.Left(false))
            {
                _animationManager.Play(_animations["Action"]);
            }
            if (Input.Right(true))
            {
                Roulade();
                _animationManager.Play(_animations["Tir"]);
            }

        }

        public void Move()
        {
            if (Input.KeyPressed(Keys.Z, false))
            {
                Velocity.Y = -Speed;
                direction = Direction.Up;
            }
            else if (Input.KeyPressed(Keys.S, false))
            {
                Velocity.Y = Speed;
                direction = Direction.Down;
            }
            else
                Velocity.Y = 0;

            if (Input.KeyPressed(Keys.Q, false))
            {
                Velocity.X = -Speed;
                direction = Direction.Left;
            }
            else if (Input.KeyPressed(Keys.D, false))
            {
                Velocity.X = Speed;
                direction = Direction.Right;
            }
            else
            {
                Velocity.X = 0;
            }

        }

        private void Roulade()
        {
            switch (direction)
            {
                case Direction.Down:
                    Tpos.Move(new Vector2(Position.X, Position.Y + 50), 500);
                    break;
                case Direction.Up:
                    Tpos.Move(new Vector2(Position.X, Position.Y - 50), 500);
                    break;
                case Direction.Left:
                    Tpos.Move(new Vector2(Position.X - 50, Position.Y), 500);
                    break;
                case Direction.Right:
                    Tpos.Move(new Vector2(Position.X + 50, Position.Y), 500);
                    break;
            }
        }

        public void Draw(SpriteBatch batch)
        {
            if (_texture != null)
                batch.Draw(_texture, Position, Color.White);
            else if (_animationManager != null)
                _animationManager.Draw(batch);
            else throw new Exception("This is aint right..");

        }
    }
}
