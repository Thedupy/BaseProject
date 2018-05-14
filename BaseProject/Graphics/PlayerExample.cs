using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BaseProject.Graphics
{
    public class PlayerExample : Sprite
    {
        public PlayerExample(Texture2D texture, Vector2 position) : base(texture, position)
        {

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

        public override void Update(GameTime time)
        {
            Move();
            base.Update(time);
        }
    }
}