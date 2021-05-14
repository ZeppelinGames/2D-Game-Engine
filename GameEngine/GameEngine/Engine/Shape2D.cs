using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Shape2D : Component
    {
        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2(1, 1);
        public string tag = "";

        public Color shapeColor;

        /// <summary>
        /// Creates new Shape2D
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="shapeColor"></param>
        public Shape2D(Color shapeColor)
        {
            this.shapeColor = shapeColor;

            Engine.RegisterComponent(this);
        }
    }
}
