using BaseProject.Utility;
using Microsoft.Xna.Framework;

namespace BaseProject.Screens
{
    public class GameScreen : Screen
    {

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            #region DemoAnimatedSprite
            //var animations = new Dictionary<string, Animation>()
            //{
            //    {"WalkUp", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkup"), 3) },
            //    {"WalkDown", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkdown"), 3) },
            //    {"WalkRight", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkright"), 3) },
            //    {"WalkLeft", new Animation(Main.Content.Load<Texture2D>("Assets/Graphics/walkleft"), 3) }
            //};

            //sprite = new AnimatedSprite(animations); 
            #endregion
        }

        public override void Update(GameTime time)
        {
            UiManager.Update(time.ElapsedGameTime.Milliseconds);
            TimerManager.Update(time.ElapsedGameTime.Milliseconds);
        }

        public override void Draw()
        {
            spriteBatch.Begin();
            UiManager.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}