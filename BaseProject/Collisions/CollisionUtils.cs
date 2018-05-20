using BaseProject.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace BaseProject.Collisions
{
    public static class CollisionUtils
    {
        #region Fields

        public static List<Sprite> Collidable { get; set; }

        #endregion

        #region Public Methods

        public static void ProcessCollision(Sprite entity)
        {
            var bounds = new Rectangle(entity.Hitbox.X, entity.Hitbox.Y, entity.Hitbox.Width, entity.Hitbox.Height);
            foreach (var sprite in Collidable)
            {
                var tBounds = new Rectangle(sprite.Hitbox.X, sprite.Hitbox.Y, sprite.Hitbox.Width, sprite.Hitbox.Height);
                var depth = new Vector2(bounds.GetHorizontalIntersectionDepth(tBounds),
                    bounds.GetVerticalIntersectionDepth(tBounds));

                if (Math.Abs(depth.Y) >= Math.Abs(depth.X))
                {
                    entity.PositionXIncrement(depth.X);
                }

                if (Math.Abs(depth.X) >= Math.Abs(depth.Y))
                {
                    entity.PositionYIncrement(depth.Y);
                }

                bounds = new Rectangle(entity.Hitbox.X, entity.Hitbox.Y, entity.Hitbox.Width, entity.Hitbox.Height);
                entity.UpdateHitbox();
            }
        }

        #endregion

        #region Private Methods

        private static float GetHorizontalIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            var halfWidthA = rectA.Width / 2.0f;
            var halfWidthB = rectB.Width / 2.0f;

            var centerA = rectA.Left + halfWidthA;
            var centerB = rectB.Left + halfWidthB;

            var distanceX = centerA - centerB;
            var minDistanceX = halfWidthA + halfWidthB;

            if (Math.Abs(distanceX) >= minDistanceX)
                return 0f;

            return distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
        }

        private static float GetVerticalIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            var halfHeightA = rectA.Height / 2.0f;
            var halfHeightB = rectB.Height / 2.0f;

            var centerA = rectA.Top + halfHeightA;
            var centerB = rectB.Top + halfHeightB;

            var distanceY = centerA - centerB;
            var minDistanceY = halfHeightA + halfHeightB;

            if (Math.Abs(distanceY) >= minDistanceY)
                return 0f;

            return distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
        }

        #endregion
    }
}