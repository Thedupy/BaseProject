using BaseProject.Graphics;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

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
                {"WalkUp", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkup"), 3) },
                {"WalkDown", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkdown"), 3) },
                {"WalkRight", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkright"), 3) },
                {"WalkLeft", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkleft"), 3) }
            };

            sprite = new AnimatedSprite(animations);
        }

        public override void Update(GameTime time)
        {
            sprite.Update(time);
            UiManager.Update(time.ElapsedGameTime.Milliseconds);
            TimerManager.Update(time.ElapsedGameTime.Milliseconds);
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