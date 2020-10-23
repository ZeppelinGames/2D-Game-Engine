using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class DemoGame : GameEngine.Engine
    {
        public DemoGame() : base(new Vector2(800, 600), "New Game")
        {

        }
    }
}
