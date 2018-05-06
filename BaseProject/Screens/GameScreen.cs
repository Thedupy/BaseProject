using BaseProject.Graphics;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BaseProject.Screens
{
    public class GameScreen : Screen
    {

        Sprite player;
        public static List<Sprite> murs;

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            player = new Sprite(Utils.CreateTexture(50, 50, Color.Red), new Vector2(200), true);

            murs = new List<Sprite>();

            for (int i = 0; i < 20; i++)
            {
                murs.Add(new Sprite(Utils.CreateTexture(Main.Rand.Next(10, 50), Main.Rand.Next(10, 50), Color.Green), new Vector2(Main.Rand.Next(0, Main.Width), Main.Rand.Next(0, Main.Height)), false));
            }

        }

        public override void Update(GameTime time)
        {
            for (int i = 0; i < murs.Count; i++)
            {
                murs[i].Update((float)time.ElapsedGameTime.TotalMilliseconds);
            }
            player.Update((float)time.ElapsedGameTime.TotalMilliseconds);
        }

        public override void Draw()
        {
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            for (int i = 0; i < murs.Count; i++)
            {
                murs[i].Draw(spriteBatch);
            }
            player.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}