using BaseProject.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BaseProject.Collisions
{
    public static class CollisionUtils
    {
        #region Public Methods

        public static bool IsCollisionFree(Rectangle currentRectangle, List<Rectangle> othersRectangles)
        {
            foreach (var otherRectangle in othersRectangles)
            {
                if (currentRectangle.Intersects(otherRectangle))
                    return false;
            }

            return true;
        }

        public static CollisionResolutionInfo CheckCollision(float timeStep, Sprite firstSprite, Sprite secondSprite)
        {
            //TODO : à faire
            return null;
        }

        #endregion

    }
}