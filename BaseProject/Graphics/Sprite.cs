using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Graphics
{
    public class Sprite : Entity
    {
        #region Fields

        public Texture2D Texture { get; }
        protected Texture2D _hitboxTexture;

        protected Rectangle _hitbox;

        public bool DisplayHitbox { get; set; } = false;

        public Rectangle Hitbox => _hitbox;

        #endregion

        #region Constructor(s)

        /// <summary>
        /// Sprite base constructor
        /// </summary>
        /// <param name="texture">The texture of the sprite</param>
        /// <param name="position">The position of the sprite</param>
        public Sprite(Texture2D texture, Vector2 position) : base(position)
        {
            Texture = texture;
            _position = position;
            _hitbox = new Rectangle((int)_position.X, (int)_position.Y, Texture.Width, Texture.Height);
            _hitboxTexture = Utils.CreateContouringTexture(Hitbox.Width, Hitbox.Height, Color.Red);
        }

        #endregion

        #region Privates Methods


        #endregion

        #region Publics Methods

        /// <summary>
        /// Update the hitbox position
        /// </summary>
        public void UpdateHitbox()
        {
            _hitbox.X = (int)Position.X;
            _hitbox.Y = (int)Position.Y;
        }

        #endregion

        #region Update & Draw Methods

        public virtual void Update(GameTime time)
        {
            //Position += Velocity;
            UpdateHitbox();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
            if (DisplayHitbox)
                spriteBatch.Draw(_hitboxTexture, Hitbox, Color.White);
        }

        #endregion

    }
}
