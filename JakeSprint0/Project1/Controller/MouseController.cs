using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class MouseController : IController
    {
        private Game game;
        private Dictionary<Rectangle, ICommand> buttonRectangles;
        private MouseState previousState, currentState;

        public MouseController(Game game)
        {
            this.game = game;
            previousState = new MouseState();
            currentState = previousState;

            buttonRectangles = new Dictionary<Rectangle, ICommand>();

        }

        public void RegisterButton(Rectangle button, ICommand command)
        {
            buttonRectangles.TryAdd(button, command);
        }

        public void Update()
        {
            // get the current state of the keyboard
            currentState = Mouse.GetState();


            // Poll each quad if the left mouse button is pressed and execute the corresponding command
            if (currentState.LeftButton == ButtonState.Pressed && previousState.LeftButton == ButtonState.Released)
            {
                foreach (KeyValuePair<Rectangle, ICommand> buttonRectangle in buttonRectangles)
                {
                    if (buttonRectangle.Key.Contains(currentState.Position))
                    {
                        buttonRectangle.Value.Execute();
                    }

                }
                
            }

            // Couldnt find a way not to hard code this...
            if (currentState.RightButton == ButtonState.Pressed)
            {
                game.Exit();
            }

            // keep this state for comparison next frame
            previousState = currentState;

        }
    }
}
