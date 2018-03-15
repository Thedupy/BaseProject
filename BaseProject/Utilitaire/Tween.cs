using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject
{
    public class TweenPosition
    {
        public Entity owner;
        public float time;
        public Vector2 begin;
        public Vector2 change;
        public float duration;
        public EaseFunction function;

        public TweenPosition(Entity _entity)
        {
            owner = _entity;
            time = 0;
            begin = owner.position;
            change = Vector2.Zero;
            duration = 0;
            function = EaseFunction.Linear;
        }

        public void Update(float _time, ref Vector2 _value)
        {
            if (time < duration)
            {
                time += _time;
                _value.X = Ease.Easing(this.time, begin.X, change.X, duration, function);
                _value.Y = Ease.Easing(this.time, begin.Y, change.Y, duration, function);
            }
        }

        public void Move(Vector2 _change, float _duration, EaseFunction _function = EaseFunction.Linear)
        {
            begin = owner.position;
            change = new Vector2(_change.X - owner.position.X, _change.Y - owner.position.Y);
            duration = _duration;
            function = _function;
            time = 0;
        }
    }

    public class TweenValue
    {
        public float value;
        public float time;
        public float begin;
        public float change;
        public float duration;
        public EaseFunction function;

        public Action<float> functor;

        public bool used, readyToRemove;

        public TweenValue()
        {
            time = 0;
            duration = 0;
            function = EaseFunction.Linear;
            used = readyToRemove = false;
        }

        public void Update(float _time)
        {
            if (time < duration)
            {
                time += _time;
                value = Ease.Easing(time, begin, change, duration, function);
                functor(value);
            }

            if (used = true && time >= duration)
            {
                readyToRemove = true;
            }
        }

        public void Move(float _value, float _change, float _duration, EaseFunction _function, Action<float> _functor)
        {
            functor = _functor;
            begin = _value;
            change = _change - begin;
            duration = _duration;
            function = _function;
            time = 0;
            used = true;
        }
    }

    public enum EaseFunction
    {
        Linear,
        EaseInQuad,
        EaseOutQuad,
        EaseInOutQuad,
        EaseInCubic,
        EaseOutCubic,
        EaseInOutCubic,
        EaseInQuart,
        EaseOutQuart,
        EaseInOutQuart,
        EaseInQuint,
        EaseOutQuint,
        EaseInOutQuint,
        EaseInSine,
        EaseOutSine,
        EaseInOutSine,
        EaseInExpo,
        EaseOutExpo,
        EaseInOutExpo,
        EaseInCirc,
        EaseOutCirc,
        EaseInOutCirc
    }

    public static class Ease
    {
        //The TRIGGER
        public static float Easing(float _t, float _b, float _c, float _d, EaseFunction _f)
        {
            switch (_f)
            {
                case EaseFunction.Linear: return LinearTween(_t, _b, _c, _d);
                case EaseFunction.EaseInQuad: return EaseInQuad(_t, _b, _c, _d);
                case EaseFunction.EaseOutQuad: return EaseOutQuad(_t, _b, _c, _d);
                case EaseFunction.EaseInOutQuad: return EaseInOutQuad(_t, _b, _c, _d);
                case EaseFunction.EaseInCubic: return EaseInCubic(_t, _b, _c, _d);
                case EaseFunction.EaseOutCubic: return EaseOutCubic(_t, _b, _c, _d);
                case EaseFunction.EaseInOutCubic: return EaseInOutCubic(_t, _b, _c, _d);
                case EaseFunction.EaseInQuart: return EaseInQuart(_t, _b, _c, _d);
                case EaseFunction.EaseOutQuart: return EaseOutQuart(_t, _b, _c, _d);
                case EaseFunction.EaseInOutQuart: return EaseInOutQuart(_t, _b, _c, _d);
                case EaseFunction.EaseInQuint: return EaseInQuint(_t, _b, _c, _d);
                case EaseFunction.EaseOutQuint: return EaseOutQuint(_t, _b, _c, _d);
                case EaseFunction.EaseInOutQuint: return EaseInOutQuint(_t, _b, _c, _d);
                case EaseFunction.EaseInSine: return EaseInSine(_t, _b, _c, _d);
                case EaseFunction.EaseOutSine: return EaseOutSine(_t, _b, _c, _d);
                case EaseFunction.EaseInOutSine: return EaseInOutSine(_t, _b, _c, _d);
                case EaseFunction.EaseInExpo: return EaseInExpo(_t, _b, _c, _d);
                case EaseFunction.EaseOutExpo: return EaseOutExpo(_t, _b, _c, _d);
                case EaseFunction.EaseInOutExpo: return EaseInOutExpo(_t, _b, _c, _d);
                case EaseFunction.EaseInCirc: return EaseInCirc(_t, _b, _c, _d);
                case EaseFunction.EaseOutCirc: return EaseOutCirc(_t, _b, _c, _d);
                case EaseFunction.EaseInOutCirc: return EaseInOutCirc(_t, _b, _c, _d);
            }

            return 0;
        }

        #region AllEase
        public static float LinearTween(float t, float b, float c, float d)
        {
            return c * t / d + b;
        }

        public static float EaseInQuad(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t + b;
        }

        public static float EaseOutQuad(float t, float b, float c, float d)
        {
            t /= d;
            return -c * t * (t - 2) + b;
        }

        public static float EaseInOutQuad(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
        }

        public static float EaseInCubic(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t + b;
        }

        public static float EaseOutCubic(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t + 1) + b;
        }

        public static float EaseInOutCubic(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t + 2) + b;
        }

        public static float EaseInQuart(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t + b;
        }

        public static float EaseOutQuart(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return -c * (t * t * t * t - 1) + b;
        }

        public static float EaseInOutQuart(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t + b;
            t -= 2;
            return -c / 2 * (t * t * t * t - 2) + b;
        }

        public static float EaseInQuint(float t, float b, float c, float d)
        {
            t /= d;
            return c * t * t * t * t * t + b;
        }

        public static float EaseOutQuint(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return c * (t * t * t * t * t + 1) + b;
        }

        public static float EaseInOutQuint(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t * t * t * t + b;
            t -= 2;
            return c / 2 * (t * t * t * t * t + 2) + b;
        }

        public static float EaseInSine(float t, float b, float c, float d)
        {
            return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        public static float EaseOutSine(float t, float b, float c, float d)
        {
            return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        public static float EaseInOutSine(float t, float b, float c, float d)
        {
            return (float)(-c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b);
        }

        public static float EaseInExpo(float t, float b, float c, float d)
        {
            return (float)(c * Math.Pow(2, 10 * (t / d - 1)) + b);
        }

        public static float EaseOutExpo(float t, float b, float c, float d)
        {
            return (float)(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
        }

        public static float EaseInOutExpo(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
            t--;
            return (float)(c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
        }

        public static float EaseInCirc(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }

        public static float EaseOutCirc(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * Math.Sqrt(1 - t * t) + b);
        }

        public static float EaseInOutCirc(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            t -= 2;
            return (float)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }
        #endregion
    }
}
