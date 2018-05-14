using BaseProject.Graphics;
using Microsoft.Xna.Framework;
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
                var distance = new Vector2();
            }
        }

        #endregion

    }
}