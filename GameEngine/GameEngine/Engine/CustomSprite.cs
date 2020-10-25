using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class CustomSprite
    {
        public int[][] spriteArray = new int[][] {
            new int[] { 1, 1, 1, 1, 1 },
            new int[] { 1, 0, 0, 0, 1 },
            new int[] { 1, 0, 1, 0, 1 },
            new int[] { 1, 0, 0, 0, 1 },
            new int[] { 1, 1, 1, 1, 1 }
        };

        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2(1, 1);
        public string tag = "";

        public Color shapeColor;

        public CustomSprite(int[][] spriteArray, Vector2 position, Vector2 scale, string tag, Color shapeColor)
        {
            this.spriteArray = spriteArray;

            this.position = position;
            this.scale = scale;

            this.tag = tag;

            this.shapeColor = shapeColor;

            Engine.RegisterCustomSprite(this);
        }

        public CustomSprite(Vector2 position, Vector2 scale, string tag, Color shapeColor)
        {
            this.spriteArray = new int[][] {
                new int[] { 1, 1, 1, 1, 1 },
                new int[] { 1, 0, 0, 0, 1 },
                new int[] { 1, 0, 1, 0, 1 },
                new int[] { 1, 0, 0, 0, 1 },
                new int[] { 1, 1, 1, 1, 1 }
            };

            this.position = position;
            this.scale = scale;

            this.tag = tag;

            this.shapeColor = shapeColor;

            Engine.RegisterCustomSprite(this);
        }

        public void Destroy()
        {
            Engine.DeregisterCustomSprite(this);
        }

        public bool isColliding(Shape2D a, Shape2D b)
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
