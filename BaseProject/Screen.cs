using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BaseProject.Utilitaire;
using System.Collections.Generic;

namespace BaseProject
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
            UiManager.Update(time);
            TimerManager.Update(time);
        }

        public override void Draw()
        {
            Batch.Begin();
            UiManager.Draw(Batch);
            Batch.End();
        }
    }
}
