using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace GameEngine
{
    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true; //Reduces flickering
        }
    }

    public abstract class Engine
    {
        private Vector2 screenSize = new Vector2(800, 600);
        private string window_Title = "GameEngine";
        private Canvas window = null;

        public Engine(Vector2 screenSize, string title)
        {
            this.screenSize = screenSize;
            this.window_Title = title;

            window = new Canvas();
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            window.Text = this.window_Title;

            Application.Run(window);
        }
    }
}
