using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
        GameObject playerGO;
        float moveSpeed = 0.5f;

        bool up, down, left, right;

        public DemoGame() : base(new Vector2(960, 540), "Demo Game") { }

        public override void OnLoad()
        {
            Log.DebugLog("OnLoad called");
            backgroundColor = Color.Black;

            //Create player object
            playerGO = new GameObject("Player", "Player", new Vector2(50,50), new Vector2(5, 5));
            playerGO.AddComponent(new CustomSprite(new int[][] {
                new int[] { 0, 4,4, 4, 0},
                new int[] { 0, 2, 2, 2, 0},
                new int[] { 2, 1, 1, 1, 2},
                new int[] { 0, 1, 1, 1, 0},
                new int[] { 0, 3, 0, 3, 0}
                }, new Color[] { Color.Transparent, Color.White, Color.Tan, Color.Blue, Color.Brown }));
            playerGO.AddComponent(new Collider2D());

            //Create collider wall
            GameObject wall = new GameObject("Wall","Wall", new Vector2(200,200), new Vector2(50,50));
            wall.AddComponent(new Shape2D(Color.Gray));
            wall.AddComponent(new Collider2D());
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

            playerGO.Move(moveDir * moveSpeed);
            //Log.DebugLog($"X:{playerGO.position.x}, Y:{playerGO.position.y}");
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
