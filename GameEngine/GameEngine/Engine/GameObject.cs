using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

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

        public GameObject(string name, string tag, Vector2 position, Vector2 scale)
        {
            this.name = name;
            this.tag = tag;

            this.position = position;
            this.scale = scale;

            Engine.RegisterGameObject(this);
        }

        public void Destroy()
        {
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
                Log.DebugLog("SET POSITION");
            }
            catch { Log.DebugWarning("Unable to get position and scale of component"); }

            //Try register component
            try { Engine.RegisterSprites(component); } catch { }
            try { Engine.RegisterShapes(component); } catch { }

            components.Add(component);
        }

        public void RemoveComponent(Type component)
        {
            components.Remove(component);
        }
    }
}
