using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using BaseProject.Utility;

namespace BaseProject.Graphics
{
    public class Sprite : Entity
    {
        protected Texture2D _texture;

        protected AnimationManager _animationManager;

        protected Dictionary<string, Animation> _animations;

        protected Vector2 _position;

        public new Vector2 Position
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

        public Sprite(Texture2D texture, Vector2 position) : base(position)
        {
            _texture = texture;
        }

        public Sprite(Dictionary<string, Animation> animations, Vector2 position) : base(position)
        {
            Position = position;
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }




        public void Update(GameTime time)
        {
            Position += Velocity;
        }

        //A UTILISER SI ANIMATIONS
        private void SetAnimation()
        {
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
