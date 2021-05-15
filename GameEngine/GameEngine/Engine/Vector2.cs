using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        /// <summary>
        /// Returns Vector2(0, 0)
        /// </summary>
        /// <returns></returns>
        public static readonly Vector2 Zero = new Vector2(0, 0);
        /// <summary>
        /// Returns Vector2(1, 1)
        /// </summary>
        /// <returns></returns>
        public static readonly Vector2 One = new Vector2(1, 1);

        public Vector2()
        {
            this.x = Zero.x;
            this.y = Zero.y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public static float Distance(Vector2 p1,Vector2 p2)
        {
           return (float)Math.Sqrt(Math.Pow(p2.x - p1.x, 2) + Math.Pow(p2.y - p1.y, 2));
        }

        public static Vector2 Flatten(Vector2 nonFlatVector)
        {
            float x = 0;
            float y = 0;
            if (nonFlatVector.x > 0) { x = 1; }
            if (nonFlatVector.x < 0) { x = -1; }
            if (nonFlatVector.y > 0) { y = 1; }
            if (nonFlatVector.y < 0) { y = -1; }

            return new Vector2(x, y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }

        public static Vector2 operator *(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x * b.x, a.y * b.y);
        }

        public static Vector2 operator /(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x / b.x, a.y / b.y);
        }

        public static Vector2 operator *(Vector2 a, float b)
        {
            return new Vector2(a.x * b, a.y * b);
        }

        public static Vector2 operator /(Vector2 a, float b)
        {
            return new Vector2(a.x / b, a.y / b);
        }
    }
}
