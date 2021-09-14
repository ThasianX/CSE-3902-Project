using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using System.Xml;

namespace Project1
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> keyBinds;

        private KeyboardState previousState, currentState;

        //sprites

        public KeyboardController()
        {
            keyBinds = new Dictionary<Keys, ICommand>();
            previousState = new KeyboardState();
            currentState = previousState;
        }

        public void RegisterCommand(Keys key, ICommand command)
        {
            keyBinds.TryAdd(key, command);
        }

        public void Update()
        {
            // get the current state of the keyboard
            currentState = Keyboard.GetState();

            // Poll each bound key
            foreach(KeyValuePair<Keys, ICommand> keyBind in keyBinds)
            {
                if (currentState.IsKeyDown(keyBind.Key) && !previousState.IsKeyDown(keyBind.Key))
                {
                    keyBind.Value.Execute();
                }
            }

            // keep this state for comparison next frame
            previousState = currentState;
            
        }
    }
}
