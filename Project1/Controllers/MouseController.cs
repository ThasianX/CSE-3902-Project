using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Interfaces;

namespace Project1.Controllers
{
    class MouseController: IController
	{
		private readonly Dictionary<int, ICommand> controllerMappings;
		private readonly Game1 myGame;

		public MouseController(Game1 game)
		{
			myGame = game;
			controllerMappings = new Dictionary<int, ICommand>();
			RegisterCommands();
		}

		private void RegisterCommands()
		{
			controllerMappings.Add(0, new QuitCommand(myGame));
			controllerMappings.Add(1, new StillSpriteCommand(myGame));
			controllerMappings.Add(2, new AnimatedSpriteCommand(myGame));
			controllerMappings.Add(3, new MovingSpriteCommand(myGame));
			controllerMappings.Add(4, new MovingAnimatedSpriteCommand(myGame));
		}

		public void Update()
		{
			MouseState mouseState = Mouse.GetState();

			int actionId = -1;

			if (mouseState.RightButton == ButtonState.Pressed)
            {
				actionId = 0;
            } else if (mouseState.LeftButton == ButtonState.Pressed)
			{
				int centerX = myGame.SCREEN_WIDTH / 2;
				int centerY = myGame.SCREEN_HEIGHT / 2;

				if (mouseState.X < centerX && mouseState.Y < centerY)
				{
					actionId = 1;
				}
				else if (mouseState.X > centerX && mouseState.Y < centerY)
				{
					actionId = 2;
				}
				else if (mouseState.X < centerX && mouseState.Y > centerY)
				{
					actionId = 3;
				} else
				{
					actionId = 4;
				}
			}

			if(controllerMappings.ContainsKey(actionId))
			{
				controllerMappings[actionId].Execute();
			}
		}
	}
}
