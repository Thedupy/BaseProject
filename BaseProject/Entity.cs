using Microsoft.Xna.Framework;

namespace BaseProject
{
    public abstract class Entity
    {
        #region Fields

        protected Vector2 _position;
        protected Vector2 _velocity = Vector2.Zero;

        public Vector2 Position
        {
            get => _position;
            set => _position = value;
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        #endregion

        #region Constructor(s)

        protected Entity(Vector2 position)
        {
            Position = position;
        }

        #endregion
    }
}
