using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

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
        int Width, Heigth;
        bool set;
        Dictionary<string, Texture2D>[] list = new Dictionary<string, Texture2D>[2];
        Dictionary<string, Texture2D> actualDic;
        public GameScreen()
            : base()
        {

        }

        public override void Create()
        {
            Width = 3;
            Heigth = 3;
            set = true;
            list[0] = Assets.ButtonDic;
            list[1] = Assets.ButtonDic2;

            actualDic = list[1];
        }

        public override void Update(float time)
        {
            UIManager.Update(time);
            TimerManager.Update(time);

            if (set)
                actualDic = list[0];
            else
                actualDic = list[1];
            if (Input.KeyPressed(Keys.Space, true))
                set = !set;

            if (Input.KeyPressed(Keys.Left,true) && Width>1)
                Width--;
            if (Input.KeyPressed(Keys.Right, true))
                Width++;

            if (Input.KeyPressed(Keys.Down, true) && Heigth > 1)
                Heigth--;
            if (Input.KeyPressed(Keys.Up, true))
                Heigth++;

        }

        public override void Draw()
        {
            Batch.Begin();
            UIManager.Draw(Batch);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Heigth; j++)
                {
                    if(i==0)
                    {
                        if(j==0)
                            Batch.Draw(actualDic["topleft"], new Vector2(i * 32, j * 32), Color.White);
                        else if(j== Heigth - 1)
                            Batch.Draw(actualDic["bottomleft"], new Vector2(i * 32, j * 32), Color.White);
                        else
                            Batch.Draw(actualDic["left"], new Vector2(i * 32, j * 32), Color.White);
                    }
                    else if (i == Width-1)
                    {
                        if (j == 0)
                            Batch.Draw(actualDic["topright"], new Vector2(i * 32, j * 32), Color.White);
                        else if (j == Heigth - 1)
                            Batch.Draw(actualDic["bottomright"], new Vector2(i * 32, j * 32), Color.White);
                        else
                            Batch.Draw(actualDic["right"], new Vector2(i * 32, j * 32), Color.White);
                    }
                    else if (j == 0)
                    {
                            Batch.Draw(actualDic["top"], new Vector2(i * 32, j * 32), Color.White);
                    }
                    else if (j == Heigth - 1)
                    {
                        
                            Batch.Draw(actualDic["bottom"], new Vector2(i * 32, j * 32), Color.White);
                    }
                    else
                        Batch.Draw(actualDic["middle"], new Vector2(i * 32, j * 32), Color.White);



                }
            }
            Batch.End();
        }
    }
}
