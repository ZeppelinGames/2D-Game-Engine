using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Windows.Forms.VisualStyles;
using System.Configuration;
using System.Diagnostics;

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

        private static List<GameObject> allGameObjects = new List<GameObject>();
        private static List<Shape2D> allShapes = new List<Shape2D>();
        private static List<Sprite> allSprites = new List<Sprite>();
        private static List<CustomSprite> allCustomSprites = new List<CustomSprite>();

        public Vector2 cameraPosition = new Vector2();
        public float cameraRotation = 0f;

        #region Engine Setup
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

            window.KeyDown += KeyDown;
            window.KeyUp += KeyUp;

            window.FormClosing += Window_FormClosing;

            //Start new thread for main loop
            Log.DebugLog("Started game loop");
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            //Open the new window
            Application.Run(window);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
            Log.DebugLog("[GAME] Ending game process");
        }

        #endregion

        private void KeyUp(object sender, KeyEventArgs e)
        {
            GetKeyUp(e);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            GetKeyDown(e);
        }

        #region Register classes
        public static void RegisterGameObject(GameObject GO)
        {
            Log.DebugLog($"[GAMEOBJECT]({GO.name}) has been registered");
            allGameObjects.Add(GO);
        }
        public static void DeregisterGameObject(GameObject GO)
        {
            Log.DebugLog($"[GAMEOBJECT]({GO.name}) has been removed from register");
            allGameObjects.Add(GO);
        }

        public static void RegisterShapes(Shape2D shape)
        {
            Log.DebugLog($"[SHAPE]({shape.tag}) has been registered");
            allShapes.Add(shape);
        }

        public static void DeregisterShape(Shape2D shape)
        {
            Log.DebugLog($"[SHAPE]({shape.tag}) has been removed from register");
            allShapes.Remove(shape);
        }

        public static void RegisterSprites(Sprite sprite)
        {
            Log.DebugLog($"[SPRITE]({sprite.tag}) has been registered");
            allSprites.Add(sprite);
        }

        public static void DeregisterSprite(Sprite sprite)
        {
            Log.DebugLog($"[SPRITE]({sprite.tag}) has been removed from register");
            allSprites.Remove(sprite);
        }

        public static void RegisterCustomSprite(CustomSprite sprite)
        {
            Log.DebugLog($"[CUSTOM SPRITE]({sprite.tag}) has been registered");
            allCustomSprites.Add(sprite);
        }

        public static void DeregisterCustomSprite(CustomSprite sprite)
        {
            Log.DebugLog($"[CUSTOM SPRITE]({sprite.tag}) has been removed from register");
            allCustomSprites.Remove(sprite);
        }
        #endregion

        #region Game Loop + Rendering
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
            g.TranslateTransform(cameraPosition.x, cameraPosition.y); //Update camera position
            g.RotateTransform(cameraRotation); //Update camera rotation

            foreach(GameObject GO in allGameObjects)
            {
                foreach (dynamic component in GO.components)
                {
                    try
                    {
                        component.position = GO.position;
                        component.scale = GO.scale;

                        Log.DebugLog($"SET POS TO X:{component.position.x}, Y:{component.position.y}");
                    }
                    catch { Log.DebugWarning("Unable to get position and scale of component"); }
                }
            }

            //Draw all registered shapes
            foreach (Shape2D shape in allShapes)
            {
                g.FillRectangle(new SolidBrush(shape.shapeColor), shape.position.x, shape.position.y, shape.scale.x, shape.scale.y);
            }

            //Draw all registered sprites
            foreach (Sprite sprite in allSprites)
            {
                g.DrawImage(sprite.sprite, sprite.position.x, sprite.position.y, sprite.scale.x, sprite.scale.y);
            }

            foreach (CustomSprite sprite in allCustomSprites)
            {
                int[][] spriteArray = sprite.spriteArray;

                for (int y = 0; y < spriteArray.Length; y++)
                {
                    for (int x = 0; x < spriteArray[y].Length; x++)
                    {
                        if (spriteArray[y][x] != 0)
                        {
                            int color = spriteArray[y][x];
                            if(color >= sprite.shapeColor.Length)
                            {
                                color = sprite.shapeColor.Length-1;
                            }

                            float posX = (sprite.position.x + (x*sprite.scale.x)) - (spriteArray[y].Length / 2);
                            float posY = (sprite.position.y + (y*sprite.scale.y)) - (spriteArray.Length / 2);

                            g.FillRectangle(new SolidBrush(sprite.shapeColor[color]), posX, posY, sprite.scale.x, sprite.scale.y);
                        }
                    }
                }
            }
        }
        #endregion

        #region Game voids
        public abstract void OnLoad();
        public abstract void Update(); //Handles movement/physics
        public abstract void OnDraw(); //Handles drawing
        public abstract void GetKeyDown(KeyEventArgs e); //Handles key press
        public abstract void GetKeyUp(KeyEventArgs e); //Handles key release
        #endregion
    }
}
