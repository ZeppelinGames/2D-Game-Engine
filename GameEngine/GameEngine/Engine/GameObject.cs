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
        public GameObject(string name, string tag, Vector2 position = null, Vector2 scale = null)
        {
            this.name = name;
            this.tag = tag;

            this.position = position != null ? position : Vector2.Zero;
            this.scale = scale != null ? scale : Vector2.One;

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

            this.position = Vector2.Zero;
            this.scale = Vector2.One;

            Engine.RegisterGameObject(this);
        }

        /// <summary>
        /// Move GameObject in a direction using collisions
        /// </summary>
        /// <param name="movePosition"></param>
        public void Move(Collider m_Col,Vector2 moveDirection)
        {
            foreach(Collider col in Engine.allColliders)
            {
                if (col.parent != m_Col.parent)
                {
                    Log.DebugWarning($"Checking {col.parent.name} with {m_Col.parent.name}");
                    if (m_Col.isColliding(col.position, col.scale))
                    {
                        Vector2 colDir = m_Col.position - this.position;
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
            this.position += moveDirection; 
        }

        public void Destroy()
        {     
            Engine.DeregisterGameObject(this);
        }

        public void AddComponent<Comp>(GameObject p) where Comp : Component
        {
            Component newComp = new Component();
            CircleCollider cc = new CircleCollider(Vector2.Zero, 5);
            cc.parent = p;
            newComp.componentType = cc;
            newComp.parent = p;

            Engine.RegisterComponent(newComp);
            this.components.Add(newComp);
        }

        public dynamic GetComponent<Comp>() where Comp : Component
        {
            foreach (Component comp in components)
            {
                if (comp.componentType is Comp)
                {
                    return comp.componentType;
                }
            }
            Log.DebugError($"Unable to get component from [{name}]");
            return null;
        }

        public void SetComponent<Comp>(Component newComp) where Comp : Component
        {
            for (int n = 0; n < components.Count; n++)
            {
                if (components[n] is Comp)
                {
                    components[n] = newComp;
                }
            }
        }

        public void RemoveComponent(Component component)
        {
            Engine.DeregisterComponent(component);
        }
    }
}
