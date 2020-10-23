using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Shape2D
    {
        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2(1, 1);
        public string tag = "";

        public Color shapeColor;

        public Shape2D(Vector2 position, Vector2 scale, string tag, Color shapeColor)
        {
            this.position = position;
            this.scale = scale;

            this.tag = tag;

            this.shapeColor = shapeColor;

            Engine.RegisterShapes(this);
        }

        public void Destroy()
        {
            Engine.DeregisterShape(this);
        }
    }
}
