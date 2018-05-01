using BaseProject.Graphics;
using BaseProject.Screens;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BaseProject
{
    class Main
    {
        public static GraphicsDeviceManager Graphics;
        public static GraphicsDevice Device;
        public static Game Instance;
        public static ContentManager Content;
        public static Random Rand;
        public static Screen CurrentScreen;

        public Main(GraphicsDeviceManager graphics, Game game)
        {
            Main.Graphics = graphics;
            Device = graphics.GraphicsDevice;
            Instance = game;
            Content = game.Content;
            Rand = new Random();
        }

        public void Initialize()
        {
            Assets.LoadAll();

            Graphics.PreferredBackBufferWidth = Utils.WindowWidth;
            Graphics.PreferredBackBufferHeight = Utils.WindowHeight;
            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.ApplyChanges();
            Instance.IsMouseVisible = true;

            SetScreen(new GameScreen());

        }

        public void Update(GameTime time)
        {
            Input.Update();

            CurrentScreen?.Update(time);
        }

        public void Draw()
        {
            Device.Clear(Color.Black);

            CurrentScreen?.Draw();
        }

        public static void SetScreen(Screen screen)
        {
            CurrentScreen = screen;
            CurrentScreen.Create();
        }
    }
}
