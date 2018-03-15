using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newperfectmodelm
{
    class Utils
    {
        //DESSIN DE HITBOX
        public static Texture2D CreateTexture(int w, int h, Color col)
        {
            Texture2D texture = new Texture2D(Main.Device, w, h);
            Color[] cols = new Color[w * h];
            for (int i = 0; i < cols.Length; i++)
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
            Texture2D texture = new Texture2D(Main.Device, width, height);
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
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
            Color[] rawdata = new Color[region.Width * region.Height];
            sheet.GetData(0, region, rawdata, 0, rawdata.Length);
            Texture2D BufferTexture = new Texture2D(Main.Device, region.Width, region.Height);
            BufferTexture.SetData(rawdata);
            return BufferTexture;
        }
    }
}
