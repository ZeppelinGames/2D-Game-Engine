using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class CustomSprite : Component
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

        public Color[] shapeColor;

        public CustomSprite(int[][] spriteArray, Color shapeColor)
        {
            this.spriteArray = spriteArray;
            this.shapeColor[0] = shapeColor;
        }

        public CustomSprite(int[][] spriteArray, Color[] shapeColors)
        {
            this.spriteArray = spriteArray;
            this.shapeColor = shapeColors;
        }

        public CustomSprite()
        {
            this.spriteArray = new int[][] {
                new int[] { 1, 0, 0, 0, 1 },
                new int[] { 0, 1, 0, 1, 0 },
                new int[] { 0, 0, 1, 0, 0 },
                new int[] { 0, 1, 0, 1, 0 },
                new int[] { 1, 0, 0, 0, 1 }
            };

            this.shapeColor[0] = Color.Pink;
        }
    }
}
