using BaseProject.Screens;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BaseProject.Graphics
{
    public class Sprite : Entity
    {

        public Texture2D Texture { get; }
        public Rectangle Hitbox => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        public List<Sprite> collidable;

        bool playable;

        public Sprite(Texture2D texture, Vector2 position, bool player) : base(position)
        {
            Texture = texture;
            Position = position;
            collidable = new List<Sprite>();
            playable = player;
        }

        public virtual void Update(float time)
        {
            if (playable)
            {
                Move();
                Position += Velocity;
                collidable = GameScreen.murs;
                ManageCollision();

            }

        }

        private void Move()
        {
            if (Input.KeyPressed(Keys.Q, false))
                _velocity.X = -5;
            else if (Input.KeyPressed(Keys.D, false))
                _velocity.X = 5;
            else
                _velocity.X = 0;

            if (Input.KeyPressed(Keys.Z, false))
                _velocity.Y = -5;
            else if (Input.KeyPressed(Keys.S, false))
                _velocity.Y = 5;
            else
                _velocity.Y = 0;
        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);

            ////DECOMMENTER SI BESOIN DE DESSINER LES HITBOX
            //Texture2D tex = Assets.CreateTexture(hitbox.Width, hitbox.Height, new Color(255, 0, 0, 50));
            //if (tex != null)
            //    batch.Draw(tex, hitbox, Color.White);
        }

        private void ManageCollision()
        {
            Rectangle bounds = new Rectangle(Hitbox.X, Hitbox.Y, Hitbox.Width, Hitbox.Height);
            for (int i = 0; i < collidable.Count; i++)
            {
                Rectangle tBounds = new Rectangle(collidable[i].Hitbox.X, collidable[i].Hitbox.Y, collidable[i].Hitbox.Width, collidable[i].Hitbox.Height);

                Vector2 depth = new Vector2(bounds.GetHorizontalIntersectionDepth(tBounds), bounds.GetVerticalIntersectionDepth(tBounds));

                if (Math.Abs(depth.Y) >= Math.Abs(depth.X))
                {
                    _position.X += depth.X;
                }

                if (Math.Abs(depth.X) >= Math.Abs(depth.Y))
                {
                    _position.Y += depth.Y;
                }

                bounds = new Rectangle(Hitbox.X, Hitbox.Y, Hitbox.Width, Hitbox.Height);

            }
        }
    }
}
