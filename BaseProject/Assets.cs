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
        public static Texture2D PixelW, PixelB;

        //SPRITE
        public static Texture2D Heart, Bouton, Skull, ButtonSet, ButtonSet2;
        public static Dictionary<string, Texture2D> ButtonDic, ButtonDic2;
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
            Skull = Main.Content.Load<Texture2D>("skull");
            Bouton = Main.Content.Load<Texture2D>("button");

            ButtonSet = Main.Content.Load<Texture2D>("buttonset");
            ButtonSet2 = Main.Content.Load<Texture2D>("buttonset2");
            //SON

            //FONT
            Font = Main.Content.Load<SpriteFont>("littlefont");

            LoadButtonSet();
        }

        private static void LoadButtonSet()
        {
            ButtonDic = new Dictionary<string, Texture2D>
            {
                { "topleft", Utils.Slice(new Rectangle(0, 0, 32, 32), ButtonSet) },
                { "top", Utils.Slice(new Rectangle(32, 0, 32, 32), ButtonSet) },
                { "topright", Utils.Slice(new Rectangle(64, 0, 32, 32), ButtonSet) },
                { "left", Utils.Slice(new Rectangle(0, 32, 32, 32), ButtonSet) },
                { "middle", Utils.Slice(new Rectangle(32, 32, 32, 32), ButtonSet) },
                { "right", Utils.Slice(new Rectangle(64, 32, 32, 32), ButtonSet) },
                { "bottomleft", Utils.Slice(new Rectangle(0, 64, 32, 32), ButtonSet) },
                { "bottom", Utils.Slice(new Rectangle(32, 64, 32, 32), ButtonSet) },
                { "bottomright", Utils.Slice(new Rectangle(64, 64, 32, 32), ButtonSet) }
            };

            ButtonDic2 = new Dictionary<string, Texture2D>
            {
                { "topleft", Utils.Slice(new Rectangle(0, 0, 32, 32), ButtonSet2) },
                { "top", Utils.Slice(new Rectangle(32, 0, 32, 32), ButtonSet2) },
                { "topright", Utils.Slice(new Rectangle(64, 0, 32, 32), ButtonSet2) },
                { "left", Utils.Slice(new Rectangle(0, 32, 32, 32), ButtonSet2) },
                { "middle", Utils.Slice(new Rectangle(32, 32, 32, 32), ButtonSet2) },
                { "right", Utils.Slice(new Rectangle(64, 32, 32, 32), ButtonSet2) },
                { "bottomleft", Utils.Slice(new Rectangle(0, 64, 32, 32), ButtonSet2) },
                { "bottom", Utils.Slice(new Rectangle(32, 64, 32, 32), ButtonSet2) },
                { "bottomright", Utils.Slice(new Rectangle(64, 64, 32, 32), ButtonSet2) }
            };
        }
        #endregion
    }
}
