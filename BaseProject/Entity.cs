using Microsoft.Xna.Framework;

namespace BaseProject
{
    public class Entity
    {
        protected Vector2 _position;
        protected Vector2 _velocity;

        public Entity(Vector2 position)
        {
            Position = position;
        }

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
    }
}
