using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using BaseProject.Utilitaire;
using System.Collections.Generic;

namespace BaseProject
{
    public class Screen
    {
        public SpriteBatch batch;

        public Screen()
        {
            batch = new SpriteBatch(Main.device);
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
            batch.Dispose();
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

        public override void Update(float _time)
        {
            UIManager.Update(_time);
            TimerManager.Update(_time);
        }

        public override void Draw()
        {
            batch.Begin();
            UIManager.Draw(batch);
            batch.End();
        }
    }
}
