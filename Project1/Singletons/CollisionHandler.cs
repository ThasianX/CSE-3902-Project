using System;
using System.Xml.Linq;
using Project1.Interfaces;
using System.Reflection;
using System.Collections.Generic;

namespace Project1
{
    public class CollisionHandler
    {
        XElement responseData;

        // Singleton instance
        private static CollisionHandler instance = new CollisionHandler();
        public static CollisionHandler Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadResponses(string path)
        {
            XDocument doc = XDocument.Load(path);
            responseData = doc.Root;
        }

        public void HandleCollision(Collision col)
        {
            // CollisionDebug(col.target, col.source, col.side); 

            // retrieve the response corresponding to the two colliding objects
            XElement targetElement = responseData.Element(col.target.CollisionType);
            XElement response = null;
            if (targetElement != null)
            {
                response = targetElement.Element(col.source.CollisionType);
            }

            // Collisions are reflexive, so swap target and source and check for response again
            if (response == null)
            {
                col = swapTarget(col);
                targetElement = responseData.Element(col.target.CollisionType);
                if (targetElement != null)
                {
                    response = targetElement.Element(col.source.CollisionType);
                }

                // If still null, the response does not exist
                if (response == null)
                {
                    // TODO: throw exception
                    return;
                }
            }

            // Execute each response command
            foreach (XElement command in response.Elements("command"))
            {
                ExecuteCommandFromElement(command, col);
            }

        }

        private void ExecuteCommandFromElement(XElement command, Collision col)
        {
            // Get the type of the command object
            Type commandType = Type.GetType(command.Attribute("type").Value);

            // Get the arguments
            List<object> args = new List<object>();
            foreach (XElement arg in command.Elements("arg"))
            {
                args.Add(parseArg(arg, col));
            }

            ConstructorInfo constructor = commandType.GetConstructor(getTypes(args.ToArray()));
            var commandInstance = (ICommand)constructor.Invoke(args.ToArray());
            commandInstance.Execute();
        }

        private object parseArg(XElement arg, Collision col)
        {
            object obj = new object();

            string argTypeName = arg.Attribute("type").Value;
            Type argType = Type.GetType(argTypeName);
            string argValue = arg.Value;

            if (argType.IsPrimitive)
            {
                
                switch (argTypeName)
                {
                    case "System.Int32":
                        obj = int.Parse(argValue);
                        break;
                    case "System.Single":
                        obj = float.Parse(argValue);
                        break;
                    case "System.Boolean":
                        obj = bool.Parse(argValue);
                        break;
                    default:
                        obj = argValue;
                        break;
                }
            }
            else
            {
                switch (argValue)
                {
                    case "SOURCE":
                        obj = col.source;
                        break;
                    case "TARGET":
                        obj = col.target;
                        break;
                    case "DIRECTION":
                        obj = col.side;
                        break;
                    case "INTERSECTION":
                        obj = col.intersection;
                        break;
                    case "COLLISION":
                        obj = col;
                        break;
                    default:
                        obj = null;
                        Console.WriteLine("unable to parse argument");
                        break;
                }
            }
            return obj;
        }

        public Collision swapTarget(Collision col)
        {
            // copy old collision
            Collision swappedCol = col;

            // swap source and target
            swappedCol.source = col.target;
            swappedCol.target = col.source;

            return swappedCol;
        }

        Type[] getTypes(object[] objects)
        {
            Type[] types = new Type[objects.Length];
            for(int i = 0; i < types.Length; i++)
            {
                types[i] = objects[i].GetType();
            }
            return types;
        }

        public void CollisionDebug(ICollidable target, ICollidable source, Direction targetCollisionSide)
        {
            // target will always be a mover
            if (source.IsMover)
            {
                Console.WriteLine($"Collision happened between mover and mover, mover get collision from {targetCollisionSide}");
            }
            else
            {
                Console.WriteLine($"Collision happened between mover and non-mover, mover get collision from {targetCollisionSide}");
            }
        }
    }
}
