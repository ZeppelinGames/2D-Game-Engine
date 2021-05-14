using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class BoxCollider : Collider
    {
        public BoxCollider(GameObject parent,Vector2 position = null, Vector2 scale = null)
        {
            this.parent = parent;
            this.position = position != null ? position : Vector2.Zero;
            this.scale = scale != null ? scale : Vector2.Zero;
        }

        public bool isColliding(BoxCollider b)
        {
            return (Math.Abs(b.position.x - position.x) * 2 < ((b.scale.x + scale.x)*2)) && (Math.Abs(b.position.y - position.y) * 2 < ((b.scale.y + scale.y)*2));
        }
    }
}
