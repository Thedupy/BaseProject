using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Utility
{
    public static class Utils
    {

        public const int WindowWidth = 1600, WindowHeight = 900;

        /// <summary>
        /// Create a texture
        /// </summary>
        /// <param name="width">The width of the texture</param>
        /// <param name="height">The height of the texture</param>
        /// <param name="color">The color of the texture</param>
        /// <returns>The created Texture2D</returns>
        public static Texture2D CreateTexture(int width, int height, Color color)
        {
            var texture = new Texture2D(Main.Device, width, height);
            var colors = new Color[width * height];
            for (var i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
            }
            texture.SetData(colors);
            return texture;
        }

        /// <summary>
        /// Create an empty texture with only the contouring 
        /// </summary>
        /// <param name="width">The width of the texture</param>
        /// <param name="height">The height of the texture</param>
        /// <param name="color">The color of the texture</param>
        /// <returns>The created Textured2D</returns>
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
    }
}
