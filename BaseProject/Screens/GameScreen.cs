using BaseProject.Graphics;
using BaseProject.Utility;
using Microsoft.Xna.Framework;

namespace BaseProject.Screens
{
    public class GameScreen : Screen
    {
        private PlayerExample _player;

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            _player = new PlayerExample(Utils.CreateTexture(50, 50, Color.Green), new Vector2(100, 100));
        }

        public override void Update(GameTime time)
        {
            _player.Update(time);
            UiManager.Update(time.ElapsedGameTime.Milliseconds);
            TimerManager.Update(time.ElapsedGameTime.Milliseconds);
        }

        public override void Draw()
        {
            spriteBatch.Begin();
            {
                _player.Draw(spriteBatch);
                UiManager.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}