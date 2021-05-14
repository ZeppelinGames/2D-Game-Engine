using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Sprite : Component
    {
        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2(1, 1);
        public string directory;
        public string tag = "";
        public Bitmap sprite= null;

        /// <summary>
        /// Creates new sprite
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="tag"></param>
        public Sprite(string directory, string tag)
        {
            this.directory = directory;
            this.tag = tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            Bitmap sprite = new Bitmap(tmp, (int)this.scale.x, (int)this.scale.y);
            this.sprite = sprite;

            Engine.RegisterComponent(this);
        }
    }
}
