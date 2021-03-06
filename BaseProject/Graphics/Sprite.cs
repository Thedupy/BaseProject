﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Graphics
{
    public class Sprite : Entity
    {

        public Texture2D Texture { get; }
        public Rectangle Hitbox => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        public Sprite(Texture2D texture, Vector2 position) : base(position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual void Update(float time)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {
            batch.Draw(Texture, Position, Color.White);

            ////DECOMMENTER SI BESOIN DE DESSINER LES HITBOX
            //Texture2D tex = Assets.CreateTexture(hitbox.Width, hitbox.Height, new Color(255, 0, 0, 50));
            //if (tex != null)
            //    batch.Draw(tex, hitbox, Color.White);
        }

    }
}
