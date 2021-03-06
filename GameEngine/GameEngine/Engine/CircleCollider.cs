﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Engine
{
    class CircleCollider : Collider
    { 
        public CircleCollider(Vector2 position = null, float radius = 1)
        {
            this.position = position != null ? position : Vector2.Zero;
            this.scale = new Vector2(radius,radius);
        }

        public override bool isColliding(Vector2 pos, Vector2 scal)
        {
            float rad = scal.x != scal.y ? scal.x > scal.y ? scal.x : scal.y : scal.x;

            float dist = Vector2.Distance(pos, this.position);
            if (dist <= (rad + scale.x))
            {
                Log.DebugLog($"CIRCLE COL {dist}");
                return true;
            }
            return false;
        }
    }
}
