using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Sprite : Entity
    {
        public Texture2D texture;

        public Rectangle Hitbox
        {
            get { return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height); }
        }

        public Sprite(Texture2D _texture, Vector2 _position) : base(_position)
        {
            this.texture = _texture;
            base.position = _position;
        }

        public virtual void Update(float _time)
        {

        }

        public virtual void Draw(SpriteBatch _batch)
        {
            _batch.Draw(texture, position, Color.White);

            ////DECOMMENTER SI BESOIN DE DESSINER LES HITBOX
            //Texture2D tex = Assets.CreateTexture(hitbox.Width, hitbox.Height, new Color(255, 0, 0, 50));
            //if (tex != null)
            //    batch.Draw(tex, hitbox, Color.White);
        }

    }
}
