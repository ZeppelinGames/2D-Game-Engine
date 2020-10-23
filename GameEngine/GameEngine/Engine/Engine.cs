using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Windows.Forms.VisualStyles;

namespace GameEngine.Engine
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
        private Thread GameLoopThread = null;

        public Color backgroundColor = Color.Black;

        private static List<Shape2D> allShapes = new List<Shape2D>();


        public Engine(Vector2 screenSize, string title)
        {
            this.screenSize = screenSize;
            this.window_Title = title;

            //Create new window to render game
            window = new Canvas();
            //Set window size
            window.Size = new Size((int)this.screenSize.x, (int)this.screenSize.y);
            //Set window title
            window.Text = this.window_Title;
            window.Paint += Renderer;

            //Start new thread for main loop
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            //Open the new window
            Application.Run(window);
        }

        public static void RegisterShapes(Shape2D shape)
        {
            allShapes.Add(shape);
        }

        void GameLoop()
        {
            OnLoad(); //Load assets before main loop begins
            while (GameLoopThread.IsAlive)
            {
                try //Make window is open
                {
                    OnDraw();
                    window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });
                    Update();
                    Thread.Sleep(1); //Allow time for refresh
                }
                catch
                {
                    Console.WriteLine("Game is loading");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(backgroundColor);
        }

        public abstract void OnLoad();
        public abstract void Update(); //Handles movement/physics
        public abstract void OnDraw(); //Handles drawing
    }
}
