using BaseProject.Utility;
using Microsoft.Xna.Framework;
using BaseProject.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Screens
{
    public class GameScreen : Screen
    {
        AnimatedSprite sprite;

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            var animations = new Dictionary<string, Animation>()
            {
                {"WalkUp", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkup"), 3,200, false) },
                {"WalkDown", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkdown"), 3,200, false) },
                {"WalkLeft", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkleft"), 3, 200, false) },
                {"WalkRight", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkright"), 3,200, false) },
                {"Action", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/action"), 3, 0.1f, true) },
                {"Tir", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/tir"), 6, 500/6, true) }
            };
            sprite = new AnimatedSprite(animations, new Vector2(100, 100));
        }

        public override void Update(GameTime time)
        {
            UiManager.Update(time.ElapsedGameTime.Milliseconds);
            TimerManager.Update(time.ElapsedGameTime.Milliseconds);
            sprite.Update(time);
        }

        public override void Draw()
        {
            spriteBatch.Begin();
            UiManager.Draw(spriteBatch);
            sprite.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}