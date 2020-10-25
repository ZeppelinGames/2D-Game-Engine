using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Collider2D
    {
        public Vector2 position;
        public Vector2 scale;

        public Collider2D(Vector2 position, Vector2 scale)
        {
            this.position = position;
            this.scale = scale;
        }

        public bool isCollidingSprite(Collider2D b)
        {
            if (position.x <= b.position.x &&
                scale.x >= b.scale.x &&
                position.y <= b.position.y &&
                scale.y >= b.scale.y)
            {
                return true;
            }
            return false;
        }
    }
}
