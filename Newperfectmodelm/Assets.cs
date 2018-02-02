using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newperfectmodelm
{
    public class Assets
    {
        #region Variable

        #endregion

        #region Methode
        public static void LoadAll()
        {
        }

        public static Texture2D Slice(Rectangle region, Texture2D sheet)
        {
            Color[] rawData = new Color[region.Width * region.Height];
            sheet.GetData(0, region, rawData, 0, rawData.Length);
            Console.ReadKey();
            Texture2D BufferTexture = new Texture2D(Main.Device, region.Width, region.Height);
            BufferTexture.SetData(rawData);
            return BufferTexture;
        }
        #endregion
    }
}
