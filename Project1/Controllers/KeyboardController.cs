using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Interfaces;

namespace Project1
{
    class KeyboardController: IController
	{
		private readonly Dictionary<Keys, ICommand> controllerMappings;
		private readonly Game1 myGame;

		public KeyboardController(Game1 game)
		{
			myGame = game;
			controllerMappings = new Dictionary<Keys, ICommand>();
			RegisterCommands();
		}

		private void RegisterCommands()
		{
			controllerMappings.Add(Keys.D0, new QuitCommand(myGame));
			controllerMappings.Add(Keys.D2, new AnimatedSpriteCommand(myGame));
			controllerMappings.Add(Keys.T, new BlockCycleLeftCommand(myGame));
			controllerMappings.Add(Keys.Y, new BlockCycleRightCommand(myGame));
		}

		//We need to modify controller so it includes key release
		public void Update()
		{
			Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

			foreach (Keys key in pressedKeys)
			{
				if(controllerMappings.ContainsKey(key))
				{
					controllerMappings[key].Execute();
				}
			}
		}
	}
}
