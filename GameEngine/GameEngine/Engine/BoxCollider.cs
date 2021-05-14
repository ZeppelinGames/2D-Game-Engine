using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class BoxCollider
    {
        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2();

        public BoxCollider()
        {
            Engine.RegisterCollider(this);
        }

        public bool isColliding(BoxCollider b)
        {
            if ((Math.Abs((position.x + scale.x / 2) - (b.position.x + b.scale.x / 2)) * 2 < (scale.x + b.scale.x)) &&
                 (Math.Abs((position.y + scale.y / 2) - (b.position.y + b.scale.y / 2)) * 2 < (scale.y + b.scale.y)))
            {
                return true;
            }
            return false;
        }

        public void Destroy()
        {
            Engine.DeregisterCollider(this);
        }
    }
}
