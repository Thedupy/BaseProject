using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class UIManager
    {
        public UIManager()
        {
        }

        public static void Update(float _time)
        {
           
            for (int i = 0; i < listParticles.Count; i++)
            {
                listParticles[i].Update(_time);
            }
            listParticles.RemoveAll(k => k.ended == true);
        }

        public static void Draw(SpriteBatch _batch)
        {
            
            for (int i = 0; i < listParticles.Count; i++)
            {
                listParticles[i].Draw(_batch);
            }
        }

        //GESTION PARTICLE
        public static void AddParticle(UI par)
        {
            listParticles.Add(par);
        }

        public static List<UI> listParticles = new List<UI>();
    }

    public class UI
    {
        public Vector2 position;
        public bool ended = false;
        public float timer;

        public UI(Vector2 _position)
        {
            this.position = _position;
        }

        public virtual void Update(float _time)
        {
        }

        public virtual void Draw(SpriteBatch _batch)
        {
            //batch.Draw(Texture, Position, Color.White);
        }

    }

    public class UILabel : UI
    {
        Color color;
        float delay;
        float speed;
        string text;
        Texture2D texture;

        public UILabel(string _text, Vector2 _position, float _delay, float _speed, Color _color) : base(_position)
        {
            this.color = _color;
            this.delay = _delay;
            this.speed = _speed;
            this.text = _text;
        }

        public UILabel(Texture2D _texture, Vector2 _position, float _delay, float _speed) : base(_position)
        {
            this.texture = _texture;
            this.delay = _delay;
            this.speed = _speed;
        }

        public override void Update(float _time)
        {
            timer += _time;
            if (timer < delay)
            {
                position.Y -= speed;
            }
            else
                ended = true;
        }

        public override void Draw(SpriteBatch _batch)
        {
            if (text != null)
                _batch.DrawString(Assets.font, text, position, color);
            else
                _batch.Draw(texture, position, Color.White);
        }
    }

    public class UIButton : UI
    {
        Texture2D texture;
        Rectangle bounds;
        Color normalColor, survoledColor, actualColor;
        WhenPressed action;

        public UIButton(Vector2 _position, int _width, int _height, Color _normalColor, Color _survoledColor, WhenPressed _action, Texture2D _texture = null) : base(_position)
        {
            bounds = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            normalColor = _normalColor;
            survoledColor = _survoledColor;
            action = _action;
            if (_texture != null)
                texture = _texture;
        }

        public UIButton(Vector2 _position, int _width, int _height, WhenPressed _action, Texture2D _texture) : base(_position)
        {
            bounds = new Rectangle((int)_position.X, (int)_position.Y, _width, _height);
            this.action = _action;
            this.texture = _texture;
        }

        public override void Update(float _time)
        {
            if(Input.mouseBox.Intersects(bounds))
            {
                actualColor = survoledColor;
                if(Input.Left(true))
                {
                    action.Invoke();
                }
            }
                else
            {
                actualColor = normalColor;
            }
        }

        public override void Draw(SpriteBatch _batch)
        {
            if (texture != null)
                _batch.Draw(texture, position, Color.White);
            else
                _batch.Draw(Assets.pixelW, bounds, actualColor);

        }

        #region codetest
        //for (int i = 0; i<Width; i++)
        //    {
        //        for (int j = 0; j<Heigth; j++)
        //        {
        //            if(i==0)
        //            {
        //                if(j==0)
        //                    Batch.Draw(actualDic["topleft"], new Vector2(i* 32, j* 32), Color.White);
        //                else if(j== Heigth - 1)
        //                    Batch.Draw(actualDic["bottomleft"], new Vector2(i* 32, j* 32), Color.White);
        //                else
        //                    Batch.Draw(actualDic["left"], new Vector2(i* 32, j* 32), Color.White);
        //            }
        //            else if (i == Width-1)
        //            {
        //                if (j == 0)
        //                    Batch.Draw(actualDic["topright"], new Vector2(i* 32, j* 32), Color.White);
        //                else if (j == Heigth - 1)
        //                    Batch.Draw(actualDic["bottomright"], new Vector2(i* 32, j* 32), Color.White);
        //                else
        //                    Batch.Draw(actualDic["right"], new Vector2(i* 32, j* 32), Color.White);
        //            }
        //            else if (j == 0)
        //            {
        //                    Batch.Draw(actualDic["top"], new Vector2(i* 32, j* 32), Color.White);
        //            }
        //            else if (j == Heigth - 1)
        //            {
                        
        //                    Batch.Draw(actualDic["bottom"], new Vector2(i* 32, j* 32), Color.White);
        //            }
        //            else
        //                Batch.Draw(actualDic["middle"], new Vector2(i* 32, j* 32), Color.White);



        //        }
        //    }
        #endregion

        public delegate void WhenPressed();
    }

    public class UIPopup : UI
    {
        public enum PopState { Open, Wait, Close};
        PopState state;
        Color actualColor, textColor;
        Rectangle bounds;
        string text;
        int maxHeight;

        public int _Height { get; }
        public string _Text { get; }

        public UIPopup(Vector2 _position, int _width, int _height, string _text, Color color, Color _textColor) : base(_position)
        {
            actualColor = color;
            maxHeight = _height;
            int prout = (int)((_position.Y + (_position.Y + _height)) / 2); 
            bounds = new Rectangle((int)_position.X, prout, _width, 0);
            _Height = _height;
            _Text = _text;
            text = _text;
            textColor = _textColor;
            state = PopState.Open;
        }

        public override void Update(float _time)
        {
            switch(state)
            {
                case PopState.Open:
                    bounds.Y--;
                    bounds.Height += 2;

                    if (bounds.Height >= maxHeight)
                        state = PopState.Wait;
                    break;
                case PopState.Wait:
                    timer += _time;
                    if (timer >= 2500)
                    {
                        state = PopState.Close;
                    }
                    break;
                case PopState.Close:
                    bounds.Y++;
                    bounds.Height -= 2;
                    if (bounds.Height < 0)
                        ended = true;
                    break;
            }
            
        }

        public override void Draw(SpriteBatch _batch)
        {
            _batch.Draw(Assets.pixelW, bounds, actualColor);
            if(state == PopState.Wait)
                _batch.DrawString(Assets.font, text, new Vector2(bounds.X, bounds.Y) + new Vector2((bounds.Width - Assets.font.MeasureString(text).X) / 2, (bounds.Height - Assets.font.MeasureString(text).Y) / 2), textColor);

        }
    }
}
