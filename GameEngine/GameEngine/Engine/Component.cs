using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Component
    {
        public GameObject parent;
        public dynamic componentType;

        public Vector2 position
        {
            get
            {
                return parent.position;
            }
            set { }
        }
        public Vector2 scale = Vector2.One;
    }
}
