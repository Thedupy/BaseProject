using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newperfectmodelm.Utilitaire
{
    class ProgressBar
    {

        #region Fields

        // Processing fields
        float width, height, percentUp, maxValue, currentValue;
        bool withLabel = false;

        // Graphics fields
        Color color;
        Texture2D barTexture, barBackgroundTexture;
        Vector2 position;
        SpriteFont font = Assets.Font;

        #endregion



        #region Constructor(s)


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="position">La position de la progress bar</param>
        /// <param name="width">La largeur</param>
        /// <param name="height">La hauteur</param>
        /// <param name="color">La couleur</param>
        /// <param name="maxValue">La valeur maximume possiblement atteinte</param>
        /// <param name="withLabel">Si la valeur est affichée au dessus de la progress bar sous ce format : valeur courante / valeur maximale</param>
        public ProgressBar(Vector2 position, float width, float height, Color color, float maxValue, bool withLabel)
        {
            this.position = position;
            this.width = width;
            this.height = height;
            this.color = color;
            this.maxValue = maxValue;
            this.withLabel = withLabel;
            currentValue = maxValue;
            percentUp = (currentValue / this.maxValue) * width;
            barBackgroundTexture = Utils.CreateTexture((int)(width + 4), (int)(height + 4), color * 0.5f);
            barTexture = Utils.CreateTexture((int)percentUp, (int)height, color);

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Décrémente la progressBar
        /// </summary>
        /// <param name="value">La valeur à décrémenter</param>
        public void DecreaseBar(int value)
        {
            currentValue -= value;
            if (currentValue <= 0)
            {
                currentValue = 0;
            }
        }

        /// <summary>
        /// Incrémente la progressBar
        /// </summary>
        /// <param name="value">La valeur à incrémenter</param>
        public void IncreaseBar(int value)
        {
            currentValue += value;
            if (currentValue >= maxValue)
            {
                currentValue = maxValue;
            }
        }

        public void Update(float time)
        {
            percentUp = (currentValue / maxValue) * width;
            if (percentUp > 0)
            {
                barTexture = Utils.CreateTexture((int)percentUp, (int)height, color);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (withLabel)
            {
                string text = currentValue + "/" + maxValue;
                spriteBatch.DrawString(font, text, new Vector2(((position.X + barBackgroundTexture.Width / 2) - (font.MeasureString(text) / 2).X), position.Y - (height + font.MeasureString(text).Y) / 2), Color.White);
            }
            spriteBatch.Draw(barBackgroundTexture, position, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 1);
            if (percentUp > 0)
            {
                spriteBatch.Draw(barTexture, new Vector2(position.X + 2, position.Y + 2), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
        }

        #endregion
    }
}
