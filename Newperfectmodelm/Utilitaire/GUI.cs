using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newperfectmodelm
{
    public class UIManager
    {
        public UIManager()
        {
        }

        public static void Update(float time)
        {
            //foreach (var item in ListParticles)
            //{
            //    item.Update(time);
            //}
            for (int i = 0; i < ListParticles.Count; i++)
            {
                ListParticles[i].Update(time);
            }
            ListParticles.RemoveAll(k => k.Ended == true);
        }

        public static void Draw(SpriteBatch batch)
        {
            //foreach (var item in ListParticles)
            //{
            //    item.Draw(batch);
            //}
            for (int i = 0; i < ListParticles.Count; i++)
            {
                ListParticles[i].Draw(batch);
            }
        }

        //GESTION PARTICLE
        public static void AddParticle(UI par)
        {
            ListParticles.Add(par);
        }

        public static List<UI> ListParticles = new List<UI>();
    }

    public class UI
    {
        public Vector2 Position;
        public bool Ended = false;
        public float timer;

        public UI(Vector2 position)
        {
            Position = position;
        }

        public virtual void Update(float time)
        {
        }

        public virtual void Draw(SpriteBatch batch)
        {
            //batch.Draw(Texture, Position, Color.White);
        }

    }

    public class UILabel : UI
    {
        Color Color;
        float Delay;
        float Speed;
        string Text;
        Texture2D Texture;

        public UILabel(string text, Vector2 position, float delay, float speed, Color color) : base(position)
        {
            Color = color;
            Delay = delay;
            Speed = speed;
            Text = text;
        }

        public UILabel(Texture2D texture, Vector2 position, float delay, float speed) : base(position)
        {
            Texture = texture;
            Delay = delay;
            Speed = speed;
        }

        public override void Update(float time)
        {
            timer += time;
            if (timer < Delay)
            {
                Position.Y -= Speed;
            }
            else
                Ended = true;
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Text != null)
                batch.DrawString(Assets.Font, Text, Position, Color);
            else
                batch.Draw(Texture, Position, Color.White);
        }
    }

    public class UIButton : UI
    {
        Texture2D Texture;
        Rectangle Bounds;
        Color NormalColor, SurvoledColor, ActualColor;
        Byte R, G, B;
        WhenPressed Action;

        public UIButton(Vector2 position, int width, int height, Color normalColor, Color survoledColor, WhenPressed action, Texture2D texture = null) : base(position)
        {
            Bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
            NormalColor = normalColor;
            SurvoledColor = survoledColor;
            Action = action;
            if (texture != null)
                Texture = texture;
        }

        public UIButton(Vector2 position, int width, int height, WhenPressed action, Texture2D texture) : base(position)
        {
            Bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
            Action = action;
            Texture = texture;
        }

        public override void Update(float time)
        {
            if(Input.MouseBox.Intersects(Bounds))
            {
                ActualColor = SurvoledColor;
                if(Input.Left(true))
                {
                    Action.Invoke();
                }
            }
                else
            {
                ActualColor = NormalColor;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Texture != null)
                batch.Draw(Texture, Position, Color.White);
            else
                batch.Draw(Assets.PixelW, Bounds, ActualColor);

        }

        public delegate void WhenPressed();
    }

    public class UIPopup : UI
    {
        public enum PopState { Open, Wait, Close};
        PopState State;
        Color ActualColor, TextColor;
        Rectangle Bounds;
        string Text;
        int Kek;

        public UIPopup(Vector2 position, int width, int height, string text, Color color, Color textColor) : base(position)
        {
            ActualColor = color;
            Kek = height;
            int prout = (int)((position.Y + (position.Y + height)) / 2); 
            Bounds = new Rectangle((int)position.X, prout, width, 0);
            Text = text;
            TextColor = textColor;
            State = PopState.Open;
        }

        public override void Update(float time)
        {
            switch(State)
            {
                case PopState.Open:
                    Bounds.Y--;
                    Bounds.Height += 2;

                    if (Bounds.Height >= Kek)
                        State = PopState.Wait;
                    break;
                case PopState.Wait:
                    timer += time;
                    if (timer >= 2500)
                    {
                        State = PopState.Close;
                    }
                    break;
                case PopState.Close:
                    Bounds.Y++;
                    Bounds.Height -= 2;
                    if (Bounds.Height < 0)
                        Ended = true;
                    break;
            }
            
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(Assets.PixelW, Bounds, ActualColor);
            if(State == PopState.Wait)
                batch.DrawString(Assets.Font, Text, new Vector2(Bounds.X, Bounds.Y) + new Vector2((Bounds.Width - Assets.Font.MeasureString(Text).X) / 2, (Bounds.Height - Assets.Font.MeasureString(Text).Y) / 2), TextColor);

        }
    }
}
