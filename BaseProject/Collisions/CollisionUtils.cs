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

        public static void ProcessCollision(Sprite player)
        {
            foreach (var sprite in Collidable)
            {
                var distance = new Vector2(player.Hitbox.GetHorizontalIntersectionDepth(sprite.Hitbox),
                    player.Hitbox.GetVerticalIntersectionDepth(sprite.Hitbox));

                if (Math.Abs(distance.Y) >= Math.Abs(distance.X))
                    player.Position = new Vector2(player.Position.X + distance.X, player.Position.Y);
                if (Math.Abs(distance.X) >= Math.Abs(distance.Y))
                    player.Position = new Vector2(player.Position.X, player.Position.Y + distance.Y);

                player.UpdateHitbox();
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