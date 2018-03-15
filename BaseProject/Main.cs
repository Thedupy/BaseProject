using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    class Main
    {
        public static GraphicsDeviceManager graphics;
        public static GraphicsDevice device;
        public static Game instance;
        public static ContentManager content;
        public static Random rand;
        public static Screen currentScreen;

        public static int Width = 800, Height = 600;

        public Main(GraphicsDeviceManager graphics, Game game)
        {
            Main.graphics = graphics;
            device = graphics.GraphicsDevice;
            instance = game;
            content = game.Content;
            rand = new Random();
        }

        public void Initialize()
        {
            Assets.LoadAll();

            graphics.PreferredBackBufferWidth = Width;
            graphics.PreferredBackBufferHeight = Height;
            graphics.SynchronizeWithVerticalRetrace = false;
            graphics.ApplyChanges();
            instance.IsMouseVisible = true;

            SetScreen(new GameScreen());

        }

        public void Update(float _time)
        {
            Input.Update();

            if (currentScreen != null) currentScreen.Update(_time);
        }

        public void Draw()
        {
            device.Clear(Color.Black);

            if (currentScreen != null) currentScreen.Draw();
        }

        public static void SetScreen(Screen _screen)
        {
            currentScreen = _screen;
            currentScreen.Create();
        }
    }
}
