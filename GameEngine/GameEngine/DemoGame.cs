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
        float moveSpeed = 0.5f;

        bool up, down, left, right;

        public DemoGame() : base(new Vector2(800, 600), "New Game") { }

        public override void OnLoad()
        {
            Log.DebugLog("OnLoad called");
            backgroundColor = Color.Black;

            player = new Shape2D(new Vector2(), new Vector2(10, 10), "Player", Color.Red);
        }

        public override void Update()
        {
            Vector2 moveDir = Vector2.Zero();
            if (up)
            {
                moveDir += new Vector2(0, -1);
            }
            if (down)
            {
                moveDir += new Vector2(0, 1);
            }
            if (left)
            {
                moveDir += new Vector2(-1, 0);
            }
            if (right)
            {
                moveDir += new Vector2(1, 0);
            }

            player.position += moveDir * moveSpeed;
        }

        public override void OnDraw()
        {

        }

        public override void GetKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = true; }
            if (e.KeyCode == Keys.S) { down = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.D) { right = true; }
        }

        public override void GetKeyUp(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { up = false; }
            if (e.KeyCode == Keys.S) { down = false; }
            if (e.KeyCode == Keys.A) { left = false; }
            if (e.KeyCode == Keys.D) { right = false; }
        }
    }
}
