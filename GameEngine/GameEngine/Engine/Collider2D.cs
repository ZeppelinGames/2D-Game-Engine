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

        public bool isCollidingSprite(Collider2D a, Sprite b)
        {
            if (a.position.x <= b.position.x &&
                a.scale.x >= b.scale.x &&
                a.position.y <= b.position.y &&
                a.scale.y >= b.scale.y)
            {
                return true;
            }
            return false;
        }
    }
}
