using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Assets
    {
        #region Variable
        public static Texture2D pixelW, pixelB;

        //SPRITE
        public static Texture2D heart, bouton, skull, buttonSet, buttonSet2;
        public static Dictionary<string, Texture2D> buttonDic, buttonDic2;
        //SON
        //FONT
        public static SpriteFont font;
        #endregion

        #region Methode
        public static void LoadAll()
        {
            pixelW = Utils.CreateTexture(1, 1, Color.White);
            pixelB = Utils.CreateTexture(1, 1, Color.Black);

            //SPRITE
            heart = Main.content.Load<Texture2D>("heart");
            skull = Main.content.Load<Texture2D>("skull");
            bouton = Main.content.Load<Texture2D>("button");

            buttonSet = Main.content.Load<Texture2D>("buttonset");
            buttonSet2 = Main.content.Load<Texture2D>("buttonset2");
            //SON

            //FONT
            font = Main.content.Load<SpriteFont>("littlefont");

            LoadButtonSet();
        }

        private static void LoadButtonSet()
        {
            buttonDic = new Dictionary<string, Texture2D>
            {
                { "topleft", Utils.Slice(new Rectangle(0, 0, 32, 32), buttonSet) },
                { "top", Utils.Slice(new Rectangle(32, 0, 32, 32), buttonSet) },
                { "topright", Utils.Slice(new Rectangle(64, 0, 32, 32), buttonSet) },
                { "left", Utils.Slice(new Rectangle(0, 32, 32, 32), buttonSet) },
                { "middle", Utils.Slice(new Rectangle(32, 32, 32, 32), buttonSet) },
                { "right", Utils.Slice(new Rectangle(64, 32, 32, 32), buttonSet) },
                { "bottomleft", Utils.Slice(new Rectangle(0, 64, 32, 32), buttonSet) },
                { "bottom", Utils.Slice(new Rectangle(32, 64, 32, 32), buttonSet) },
                { "bottomright", Utils.Slice(new Rectangle(64, 64, 32, 32), buttonSet) }
            };

            buttonDic2 = new Dictionary<string, Texture2D>
            {
                { "topleft", Utils.Slice(new Rectangle(0, 0, 32, 32), buttonSet2) },
                { "top", Utils.Slice(new Rectangle(32, 0, 32, 32), buttonSet2) },
                { "topright", Utils.Slice(new Rectangle(64, 0, 32, 32), buttonSet2) },
                { "left", Utils.Slice(new Rectangle(0, 32, 32, 32), buttonSet2) },
                { "middle", Utils.Slice(new Rectangle(32, 32, 32, 32), buttonSet2) },
                { "right", Utils.Slice(new Rectangle(64, 32, 32, 32), buttonSet2) },
                { "bottomleft", Utils.Slice(new Rectangle(0, 64, 32, 32), buttonSet2) },
                { "bottom", Utils.Slice(new Rectangle(32, 64, 32, 32), buttonSet2) },
                { "bottomright", Utils.Slice(new Rectangle(64, 64, 32, 32), buttonSet2) }
            };
        }
        #endregion
    }
}
