using BaseProject.Collisions;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace BaseProject.Graphics
{
    public class PlayerExample : Sprite
    {
        private const float MoveSpeed = 5f;

        public PlayerExample(Texture2D texture, Vector2 position) : base(texture, position)
        {

        }

        private void Move()
        {
            if (Input.KeyPressed(Keys.Q, false))
                _velocity.X = -1;
            else if (Input.KeyPressed(Keys.D, false))
                _velocity.X = 1;
            else
                _velocity.X = 0;

            if (Input.KeyPressed(Keys.Z, false))
                _velocity.Y = -1;
            else if (Input.KeyPressed(Keys.S, false))
                _velocity.Y = 1;
            else
                _velocity.Y = 0;
        }

        public override void Update(GameTime time)
        {
            Move();
            Position += Velocity * MoveSpeed;
            CollisionUtils.ProcessCollision(this);
            Debug.Print("Position X : " + Position.X + " Position Y : " + Position.Y);
            Debug.Print("Velocity X : " + Velocity.X + " Velocity Y : " + Velocity.Y + "\n");
            base.Update(time);
        }
    }
}