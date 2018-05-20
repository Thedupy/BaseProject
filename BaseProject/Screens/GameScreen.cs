using BaseProject.Collisions;
using BaseProject.Graphics;
using BaseProject.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BaseProject.Screens
{
    public class GameScreen : Screen
    {
        private PlayerExample _player;

        private List<Sprite> _walls;

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            _player = new PlayerExample(Utils.CreateTexture(50, 50, Color.Green), new Vector2(100, 100))
            {
                DisplayHitbox = true
            };
            _walls = new List<Sprite> { new Sprite(Utils.CreateTexture(15, 20, Color.Blue), new Vector2(25, 200)), new Sprite(Utils.CreateTexture(50, 100, Color.White), new Vector2(200, 60)) };
            foreach (var sprite in _walls)
            {
                sprite.DisplayHitbox = true;
            }
        }

        public override void Update(GameTime time)
        {

            _walls.ForEach(wall => wall.Update(time));
            CollisionUtils.Collidable = _walls;
            _player.Update(time);
            UiManager.Update(time.ElapsedGameTime.Milliseconds);
            TimerManager.Update(time.ElapsedGameTime.Milliseconds);
        }

        public override void Draw()
        {
            spriteBatch.Begin();
            {
                _walls.ForEach(wall => wall.Draw(spriteBatch));
                _player.Draw(spriteBatch);
                UiManager.Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}