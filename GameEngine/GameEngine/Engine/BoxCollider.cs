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

        public override bool isColliding(Vector2 bPos, Vector2 bScale)
        {
            return (Math.Abs(bPos.x - position.x) * 2 < ((bScale.x + scale.x)*2)) && (Math.Abs(bPos.y - position.y) * 2 < ((bScale.y + scale.y)*2));
        }
    }
}
