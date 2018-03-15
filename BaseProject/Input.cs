using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    class Input
    {
        private static KeyboardState oldK, currentK;
        private static MouseState oldM, currentM;

        public static Rectangle mouseBox;
        public static Vector2 mousePos;

        public static void Update()
        {
            oldK = currentK;
            oldM = currentM;

            currentK = Keyboard.GetState();
            currentM = Mouse.GetState();

            mouseBox = new Rectangle(currentM.X, currentM.Y, 1, 1);
            mousePos = new Vector2(currentM.X, currentM.Y);
        }

        public static bool KeyPressed(Keys _k, bool _u)
        {
            return _u ? (oldK[_k] == KeyState.Up && currentK[_k] == KeyState.Down) : (currentK[_k] == KeyState.Down);
        }

        public static bool Left(bool _u)
        {
            return _u ? (oldM.LeftButton == ButtonState.Released && currentM.LeftButton == ButtonState.Pressed) : (currentM.LeftButton == ButtonState.Pressed);
        }

        public static bool Right(bool _u)
        {
            return _u ? (oldM.RightButton == ButtonState.Released && currentM.RightButton == ButtonState.Pressed) : (currentM.RightButton == ButtonState.Pressed);
        }

        public static bool Middle(bool _u)
        {
            return _u ? (oldM.MiddleButton == ButtonState.Released && currentM.MiddleButton == ButtonState.Pressed) : (currentM.MiddleButton == ButtonState.Pressed);
        }

        public static bool MouseOn(Rectangle _source)
        {
            return _source.Contains(mousePos);
        }
    }
}
