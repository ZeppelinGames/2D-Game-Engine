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
        private static List<Sprite> allSprites = new List<Sprite>();

        public Engine(Vector2 screenSize, string title)
        {
            Log.DebugLog("Game is starting");
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
            Log.DebugLog("Started game loop");
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            //Open the new window
            Application.Run(window);
        }

        public static void RegisterShapes(Shape2D shape)
        {
            Log.DebugLog($"Registered new shape: {shape.tag}");
            allShapes.Add(shape);
        }

        public static void DeregisterShape(Shape2D shape)
        {
            Log.DebugLog($"Deregistered shape: {shape.tag}");
            allShapes.Remove(shape);
        }

        public static void RegisterSprites(Sprite sprite)
        {
            Log.DebugLog($"Registered new shape: {sprite.tag}");
            allSprites.Add(sprite);
        }

        public static void DeregisterSprite(Sprite sprite)
        {
            Log.DebugLog($"Deregistered shape: {sprite.tag}");
            allSprites.Remove(sprite);
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
                    Log.DebugWarning("Game window could not be found");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(backgroundColor); //Set background color

            foreach (Shape2D shape in allShapes)
            {
                g.FillRectangle(new SolidBrush(shape.shapeColor), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
            }

            foreach (Sprite sprite in allSprites)
            {
                g.DrawImage(sprite.sprite, sprite.position.x, sprite.position.y, sprite.scale.x, sprite.scale.y);
            }
        }

        public abstract void OnLoad();
        public abstract void Update(); //Handles movement/physics
        public abstract void OnDraw(); //Handles drawing
    }
}
