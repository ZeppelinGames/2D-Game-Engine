using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public abstract class Collider : Component
    {
        public abstract bool isColliding(Vector2 position, Vector2 scale);
    }
}
