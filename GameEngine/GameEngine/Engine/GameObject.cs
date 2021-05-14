using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GameEngine.Engine
{
    public class GameObject
    {
        public string name;
        public string tag;

        public Vector2 position;
        public Vector2 scale;
        public float rotation;

        public List<dynamic> components = new List<dynamic>();

        /// <summary>
        /// Creates new GameObject
        /// </summary>
        /// <param name="name"></param>
        /// <param name="tag"></param>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        public GameObject(string name, string tag, Vector2 position = null, Vector2 scale = null, dynamic[] components = null)
        {
            this.name = name;
            this.tag = tag;

            this.position = position != null ? position : Vector2.Zero;
            this.scale = scale != null ? scale : Vector2.One;

            if (components != null)
            {
                foreach (dynamic comp in components)
                {
                    AddComponent(comp);
                }
            }

            Engine.RegisterGameObject(this);
        }

        /// <summary>
        /// Creates new GameObject at (0,0)
        /// </summary>
        /// <param name="name"></param>
        public GameObject(string name)
        {
            this.name = name;
            this.tag = "Default";

            this.position = new Vector2();
            this.scale = new Vector2(10,10);

            Engine.RegisterGameObject(this);
        }

        /// <summary>
        /// Move GameObject in a direction using collisions
        /// </summary>
        /// <param name="movePosition"></param>
        public void Move(Vector2 moveDirection)
        {
            foreach (Collider2D col in Engine.allColliders)
            {
                Collider2D thisCol = null;
                foreach (dynamic component in components)
                {
                    try { thisCol = component; } catch { }
                }
                if (thisCol != null)
                {
                    if (thisCol != col)
                    {
                        if (thisCol.isColliding(col))
                        {   
                            Vector2 colDir = col.position - this.position;
                            Vector2 normColDir = Vector2.Flatten(colDir);
                            
                            //STUCK - MOVE BACK
                            if(Vector2.Flatten(moveDirection) == normColDir)
                            {
                                this.position -= moveDirection;
                            }

                            Vector2 flatMoveDir = Vector2.Flatten(moveDirection);
                            if(flatMoveDir.x >= normColDir.x)
                            {
                                if (moveDirection.x < 0)
                                {
                                    moveDirection.x = 0;
                                }
                            }
                            if (flatMoveDir.x <= normColDir.x)
                            {
                                if (moveDirection.x > 0)
                                {
                                    moveDirection.x = 0;
                                }
                            }
                            if (flatMoveDir.y >= normColDir.y)
                            {
                                if (flatMoveDir.y < 0)
                                {
                                    moveDirection.y = 0;
                                }
                            }
                            if (flatMoveDir.y <= normColDir.y)
                            {
                                if (flatMoveDir.y > 0)
                                {
                                    moveDirection.y = 0;
                                }
                            }
                        }
                    }
                }
            }
            this.position += moveDirection;
        }

        public void Destroy()
        {
            foreach(dynamic component in components)
            {
                try { Engine.DeregisterSprite(component); } catch { }
                try { Engine.DeregisterShape(component); } catch { }
                try { Engine.DeregisterCustomSprite(component); } catch { }
            }                   

            Engine.DeregisterGameObject(this);
        }

        public void AddComponent(dynamic component)
        {
            try
            {
                Vector2 componentPos = component.position;
                Vector2 componentScale = component.scale;

                componentPos = this.position;
                componentScale = this.scale;
            }
            catch { Log.DebugWarning("Unable to get position and scale of component"); }

            //Try register component
            try { Engine.RegisterSprites(component); } catch { }
            try { Engine.RegisterShapes(component); } catch { }
            try { Engine.RegisterCustomSprite(component); } catch { }

            components.Add(component);
        }

        public void AddComponents(dynamic[] components)
        {
            if (components != null)
            {
                foreach (dynamic comp in components)
                {
                    AddComponent(comp);
                }
            }
        }

        public dynamic GetComponent(dynamic component)
        {
            try
            {
                return component;
            }
            catch
            {
                Log.DebugError($"Unable to get component from [{name}]");
                return null;
            }
        }

        public void RemoveComponent(dynamic component)
        {
            try { components.Remove(component); } catch { Log.DebugError($"Unable to remove component from [{name}]"); }

            try { Engine.DeregisterSprite(component); } catch { }
            try { Engine.DeregisterShape(component); } catch { }
            try { Engine.DeregisterCustomSprite(component); } catch { }
        }
    }
}
