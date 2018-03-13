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
        public static Texture2D PixelW, PixelB;

        //SPRITE
        public static Texture2D Heart;
        //SON
        //FONT
        public static SpriteFont Font;
        #endregion

        #region Methode
        public static void LoadAll()
        {
            PixelW = Utils.CreateTexture(1, 1, Color.White);
            PixelB = Utils.CreateTexture(1, 1, Color.Black);

            //SPRITE
            Heart = Main.Content.Load<Texture2D>("heart");
            //SON

            //FONT
            Font = Main.Content.Load<SpriteFont>("littlefont");
        }
        #endregion
    }
}
