﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    public class Sprite
    {
        public Vector2 position = new Vector2();
        public Vector2 scale = new Vector2(1, 1);
        public string directory;
        public string tag = "";
        public Bitmap sprite= null;


        public Sprite(Vector2 position, Vector2 scale,string directory, string tag)
        {
            this.position = position;
            this.scale = scale;

            this.directory = directory;
            this.tag = tag;

            Image tmp = Image.FromFile($"Assets/Sprites/{directory}.png");
            Bitmap sprite = new Bitmap(tmp, (int)this.scale.x, (int)this.scale.y);
            this.sprite = sprite;

            Engine.RegisterSprites(this);
        }

        public bool isColliding(Sprite a, Sprite b)
        {
            if (a.position.x <= b.position.x &&
                a.scale.x >= b.scale.x &&
                a.position.y <= b.position.y &&
                a.scale.y >= b.scale.y)
            {
                return true;
            }
            return false;
        }

        public void Destroy()
        {
            Engine.DeregisterSprite(this);
        }
    }
}