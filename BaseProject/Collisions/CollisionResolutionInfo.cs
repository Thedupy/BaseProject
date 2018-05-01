using BaseProject.Graphics;
using Microsoft.Xna.Framework;

namespace BaseProject.Collisions
{
    public class CollisionResolutionInfo
    {
        #region Fields

        public Vector2 FirstVelocity { get; }
        public Vector2 SecondVelocity { get; }

        public Rectangle FirstHitbox { get; }
        public Rectangle SecondHitbox { get; }

        public bool FirstOutOfBounds { get; set; }
        public bool SecondOutOfBounds { get; set; }

        #endregion

        #region Constructor(s)

        public CollisionResolutionInfo(Sprite firstSprite, bool firstOutOfBounds, Sprite secondSprite,
            bool secondOutOfBounds)
        {
            FirstVelocity = firstSprite.Velocity;
            SecondVelocity = secondSprite.Velocity;
            FirstHitbox = firstSprite.Hitbox;
            SecondHitbox = secondSprite.Hitbox;
            FirstOutOfBounds = firstOutOfBounds;
            SecondOutOfBounds = secondOutOfBounds;
        }

        #endregion
    }
}