using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Screens
{
    public abstract class Screen
    {
        public SpriteBatch spriteBatch;



        public Screen()
        {
            spriteBatch = new SpriteBatch(Main.Device);
        }

        public abstract void Create();

        public abstract void Update(GameTime time);

        public abstract void Draw();

        public void Dispose()
        {
            spriteBatch.Dispose();
        }
    }


}
