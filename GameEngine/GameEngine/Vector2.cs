using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Vector2
    {
        public float x { get; set; }
        public float y { get; set; }

        public Vector2()
        {
            this.x = Zero().x;
            this.y = Zero().y;
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// Returns Vector2(0,0)
        /// </summary>
        /// <returns></returns>
        public static Vector2 Zero()
        {
            return new Vector2(0, 0);
        }
    }
}
