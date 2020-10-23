using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    class DemoGame : Engine
    {
        public DemoGame() : base(new Vector2(800, 600), "New Game") { }

        public override void OnLoad()
        {
            Console.WriteLine("OnLoad called");
            backgroundColor = Color.Black;
        }

        public override void Update()
        {
        }

        public override void OnDraw()
        {
        }
    }
}
