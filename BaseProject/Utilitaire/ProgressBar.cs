using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BaseProject.Utilitaire
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
        SpriteFont font = Assets.font;

        #endregion



        #region Constructor(s)


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_position">La position de la progress bar</param>
        /// <param name="_width">La largeur</param>
        /// <param name="_height">La hauteur</param>
        /// <param name="_color">La couleur</param>
        /// <param name="_maxValue">La valeur maximume possiblement atteinte</param>
        /// <param name="_withLabel">Si la valeur est affichée au dessus de la progress bar sous ce format : valeur courante / valeur maximale</param>
        public ProgressBar(Vector2 _position, float _width, float _height, Color _color, float _maxValue, bool _withLabel)
        {
            position = _position;
            width = _width;
            height = _height;
            color = _color;
            maxValue = _maxValue;
            withLabel = _withLabel;
            currentValue = _maxValue;
            percentUp = (currentValue / this.maxValue) * _width;
            barBackgroundTexture = Utils.CreateTexture((int)(_width + 4), (int)(_height + 4), _color * 0.5f);
            barTexture = Utils.CreateTexture((int)percentUp, (int)_height, _color);

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Décrémente la progressBar
        /// </summary>
        /// <param name="_value">La valeur à décrémenter</param>
        public void DecreaseBar(int _value)
        {
            currentValue -= _value;
            if (currentValue <= 0)
            {
                currentValue = 0;
            }
        }

        /// <summary>
        /// Incrémente la progressBar
        /// </summary>
        /// <param name="_value">La valeur à incrémenter</param>
        public void IncreaseBar(int _value)
        {
            currentValue += _value;
            if (currentValue >= maxValue)
            {
                currentValue = maxValue;
            }
        }

        public void Update(float _time)
        {
            percentUp = (currentValue / maxValue) * width;
            if (percentUp > 0)
            {
                barTexture = Utils.CreateTexture((int)percentUp, (int)height, color);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {

            if (withLabel)
            {
                string text = currentValue + "/" + maxValue;
                _spriteBatch.DrawString(font, text, new Vector2(((position.X + barBackgroundTexture.Width / 2) - (font.MeasureString(text) / 2).X), position.Y - (height + font.MeasureString(text).Y) / 2), Color.White);
            }
            _spriteBatch.Draw(barBackgroundTexture, position, null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 1);
            if (percentUp > 0)
            {
                _spriteBatch.Draw(barTexture, new Vector2(position.X + 2, position.Y + 2), null, Color.White, 0f, Vector2.Zero, 1, SpriteEffects.None, 1);
            }
        }

        #endregion
    }
}
