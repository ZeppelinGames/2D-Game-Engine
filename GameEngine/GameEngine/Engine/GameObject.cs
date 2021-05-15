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

        public List<Component> components = new List<Component>();

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
            this.scale = new Vector2(10, 10);

            Engine.RegisterGameObject(this);
        }

        /// <summary>
        /// Move GameObject in a direction using collisions
        /// </summary>
        /// <param name="movePosition"></param>
        public void Move(Collider m_Col,Vector2 moveDirection)
        {
/*            Collider m_Col = null;
            try { m_Col = GetComponent(typeof(Collider)); } catch { }*/
            if (m_Col != null)
            {
                foreach (Collider col in Engine.allColliders)
                {
                    if (col != m_Col)
                    {
                        if (col.isColliding(col.position, col.scale))
                        {
                            Vector2 colDir = col.position - this.position;
                            Vector2 normColDir = Vector2.Flatten(colDir);

                            //STUCK - MOVE BACK
                            if (Vector2.Flatten(moveDirection) == normColDir)
                            {
                                this.position -= moveDirection;
                            }

                            Vector2 flatMoveDir = Vector2.Flatten(moveDirection);
                            if (flatMoveDir.x >= normColDir.x)
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
            Engine.DeregisterGameObject(this);
        }

        public void AddComponent(dynamic component)
        {
            if (component != null)
            {
                Component newComponent = new Component();
                newComponent.componentType = component;
                newComponent.parent = this;

                Engine.RegisterComponent(newComponent);

                components.Add(component);
            }  else
            {
                Log.DebugError("TRIED TO ADD NULL COMPONENT");
            }
        }

        public dynamic GetComponent<Comp>(Component c) where Comp : Component
        {
            dynamic component = c;
            if (component == typeof(Component))
            {
                Log.DebugLog("IS COMP");
                foreach (Component comp in components)
                {
                    if (comp.componentType == component.componentType)
                    {
                        try
                        {
                            return comp;
                        }
                        catch { }
                    }
                }
            }
            Log.DebugError($"Unable to get component from [{name}]");
            return null;
        }

        public void RemoveComponent(Component component)
        {
            Engine.DeregisterComponent(component);
        }
    }
}
