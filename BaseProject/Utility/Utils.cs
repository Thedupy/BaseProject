using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BaseProject
{
    public static class Utils
    {
        //DESSIN DE HITBOX
        public static Texture2D CreateTexture(int w, int h, Color col)
        {
            var texture = new Texture2D(Main.Device, w, h);
            var cols = new Color[w * h];
            for (var i = 0; i < cols.Length; i++)
            {
                cols[i] = col;
            }
            texture.SetData(cols);
            return texture;
        }

        /// <summary>
        /// Dessine une texture creuse, avec seulement les contours
        /// </summary>
        /// <param name="width">La largeur</param>
        /// <param name="height">La hauteur</param>
        /// <param name="color">La couleur</param>
        /// <returns>Retourne la texture sous forme Texture2D</returns>
        public static Texture2D CreateContouringTexture(int width, int height, Color color)
        {
            var texture = new Texture2D(Main.Device, width, height);
            var colors = new Color[width * height];
            for (var i = 0; i < colors.Length; i++)
            {
                if ((i >= 0 && i < width) || (i > ((colors.Length - 1) - width) && i <= colors.Length - 1))
                {
                    colors[i] = color;
                }
                if (i % width == 0)
                {
                    colors[i] = color;
                    if (i > 0)
                    {
                        colors[i - 1] = color;
                    }
                }
            }

            texture.SetData(colors);

            return texture;
        }

        public static Texture2D Slice(Rectangle region, Texture2D sheet)
        {
            var rawdata = new Color[region.Width * region.Height];
            sheet.GetData(0, region, rawdata, 0, rawdata.Length);
            var bufferTexture = new Texture2D(Main.Device, region.Width, region.Height);
            bufferTexture.SetData(rawdata);
            return bufferTexture;
        }

        public static float GetHorizontalIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            float halfWidthA = rectA.Width / 2.0f;
            float halfWidthB = rectB.Width / 2.0f;

            float centerA = rectA.Left + halfWidthA;
            float centerB = rectB.Left + halfWidthB;

            float distanceX = centerA - centerB;
            float minDistanceX = halfWidthA + halfWidthB;

            if (Math.Abs(distanceX) >= minDistanceX)
                return 0f;

            return distanceX > 0 ? minDistanceX - distanceX : -minDistanceX - distanceX;
        }

        public static float GetVerticalIntersectionDepth(this Rectangle rectA, Rectangle rectB)
        {
            float halfHeightA = rectA.Height / 2.0f;
            float halfHeightB = rectB.Height / 2.0f;

            float centerA = rectA.Top + halfHeightA;
            float centerB = rectB.Top + halfHeightB;

            float distanceY = centerA - centerB;
            float minDistanceY = halfHeightA + halfHeightB;

            if (Math.Abs(distanceY) >= minDistanceY)
                return 0f;

            return distanceY > 0 ? minDistanceY - distanceY : -minDistanceY - distanceY;
        }
    }
}
