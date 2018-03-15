using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    class Utils
    {
        //DESSIN DE HITBOX
        public static Texture2D CreateTexture(int _w, int _h, Color _col)
        {
            Texture2D texture = new Texture2D(Main.device, _w, _h);
            Color[] cols = new Color[_w * _h];
            for (int i = 0; i < cols.Length; i++)
            {
                cols[i] = _col;
            }
            texture.SetData(cols);
            return texture;
        }

        /// <summary>
        /// Dessine une texture creuse, avec seulement les contours
        /// </summary>
        /// <param name="_width">La largeur</param>
        /// <param name="_height">La hauteur</param>
        /// <param name="_color">La couleur</param>
        /// <returns>Retourne la texture sous forme Texture2D</returns>
        public static Texture2D CreateContouringTexture(int _width, int _height, Color _color)
        {
            Texture2D texture = new Texture2D(Main.device, _width, _height);
            Color[] colors = new Color[_width * _height];
            for (int i = 0; i < colors.Length; i++)
            {
                if ((i >= 0 && i < _width) || (i > ((colors.Length - 1) - _width) && i <= colors.Length - 1))
                {
                    colors[i] = _color;
                }
                if (i % _width == 0)
                {
                    colors[i] = _color;
                    if (i > 0)
                    {
                        colors[i - 1] = _color;
                    }
                }
            }

            texture.SetData(colors);

            return texture;
        }

        public static Texture2D Slice(Rectangle _region, Texture2D _sheet)
        {
            Color[] rawdata = new Color[_region.Width * _region.Height];
            _sheet.GetData(0, _region, rawdata, 0, rawdata.Length);
            Texture2D BufferTexture = new Texture2D(Main.device, _region.Width, _region.Height);
            BufferTexture.SetData(rawdata);
            return BufferTexture;
        }
    }
}
