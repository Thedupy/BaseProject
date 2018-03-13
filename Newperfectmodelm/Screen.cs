using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Newperfectmodelm
{
    public class Screen
    {
        public SpriteBatch Batch;

        public Screen()
        {
            Batch = new SpriteBatch(Main.Device);
        }

        public virtual void Create()
        {

        }

        public virtual void Update(float time)
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void Dispose()
        {
            Batch.Dispose();
        }
    }

    public class GameScreen : Screen
    {

        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            
        }

        public override void Update(float time)
        {
            UIManager.Update(time);

            if(Input.Right(true))
            {
                UIManager.AddParticle(new UILabel(Assets.Heart, new Vector2(Main.Rand.Next(Main.Width), Main.Rand.Next(200, Main.Height)), 1500, 1));
            }

            if(Input.KeyPressed(Keys.Z, true))
            {
                UIManager.AddParticle(new UIPopup(new Vector2(200,250), 400, 100, "Je vous aime", Color.White, Color.Black));
            }
        }

        public override void Draw()
        {
            Batch.Begin();
            UIManager.Draw(Batch);
            Batch.End();
        }
    }
}
