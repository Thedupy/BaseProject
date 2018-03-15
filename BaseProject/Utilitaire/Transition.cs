using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class Transition
    {
        public Texture2D texture;
        public Color color;
        public bool action;
        public bool change;
        public Screen screenToChange;

        int alphaValue = 1;
        int fadeIncrement = 3;
        double fadeDelay = 0.35;
        int cptFade = 0;

        public Transition()
        {
            texture = Assets.pixelB;
            color = Color.Transparent;
            action = false;
        }

        public void Update(float _time)
        {
            if (action)
            {
                fadeDelay -= _time;

                if (fadeDelay <= 0)
                {
                    fadeDelay = 3;
                    alphaValue += fadeIncrement;

                    if (alphaValue >= 255 || alphaValue <= 0)
                    {
                        if (alphaValue >= 255)
                            change = true;
                        fadeIncrement *= -1;
                        cptFade++;
                    }
                }

                if (change)
                {
                    change = false;
                    Main.SetScreen(screenToChange);
                }

                if (cptFade == 2)
                {
                    action = false;
                    cptFade = 0;
                }
            }
        }

        public void Fade(Screen _newScreen)
        {
            screenToChange = _newScreen;
            action = true;
        }

        public void Draw(SpriteBatch _batch)
        {
            _batch.Draw(texture, new Rectangle(0, 0, Main.Width, Main.Height), new Color(0, 0, 0, MathHelper.Clamp(alphaValue, 0, 255)));
        }
    }
}
