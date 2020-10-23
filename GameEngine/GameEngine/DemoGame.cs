using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace GameEngine.Engine
{
    class DemoGame : Engine
    {
        Shape2D player;
        public DemoGame() : base(new Vector2(800, 600), "New Game") { }

        public override void OnLoad()
        {
            Log.DebugLog("OnLoad called");
            backgroundColor = Color.Black;

            player = new Shape2D(new Vector2(), new Vector2(10, 10), "Player", Color.Red);
        }

        public override void Update()
        {
           
        }

        public override void OnDraw()
        {
        }
    }
}
