using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Interfaces;

namespace Project1
{
    class KeyboardController: IController
	{
		private readonly Dictionary<Keys, ICommand> onPressMappings;
		private readonly Dictionary<Keys, ICommand> onReleaseMappings;
		private readonly Game1 myGame;
		private KeyboardState currentState;
		private KeyboardState oldState;

		public KeyboardController(Game1 game)
		{
			myGame = game;

			onPressMappings = new Dictionary<Keys, ICommand>();
			onReleaseMappings = new Dictionary<Keys, ICommand>();

			RegisterCommands();

			oldState = Keyboard.GetState();
		}

		private void RegisterCommands()
		{
			// COMMANDS THAT EXECUTE ON PRESS =============================================
			onPressMappings.Add(Keys.D0, new QuitCommand(myGame));

			// Player 
			onPressMappings.Add(Keys.Up, new PlayerFaceUpCommand(myGame));
			onPressMappings.Add(Keys.Right, new PlayerFaceRightCommand(myGame));
			onPressMappings.Add(Keys.Down, new PlayerFaceDownCommand(myGame));
			onPressMappings.Add(Keys.Left, new PlayerFaceLeftCommand(myGame));

			onPressMappings.Add(Keys.W, new PlayerMoveUpCommand(myGame));
			onPressMappings.Add(Keys.D, new PlayerMoveRightCommand(myGame));
			onPressMappings.Add(Keys.S, new PlayerMoveDownCommand(myGame));
			onPressMappings.Add(Keys.A, new PlayerMoveLeftCommand(myGame));

			onPressMappings.Add(Keys.Z, new PlayerSwordAttackCommand(myGame));
			onPressMappings.Add(Keys.D1, new PlayerBoomerangAttackCommand(myGame));

			// Block cycling
			onPressMappings.Add(Keys.T, new BlockCycleLeftCommand(myGame));
			onPressMappings.Add(Keys.Y, new BlockCycleRightCommand(myGame));
			onPressMappings.Add(Keys.U, new ItemCycleLeftCommand(myGame));
			onPressMappings.Add(Keys.I, new ItemCycleRightCommand(myGame));

			// COMMANDS THAT EXECUTE ON RELEASE

			// Player
			onReleaseMappings.Add(Keys.W, new PlayerStopMoveUpCommand(myGame));
			onReleaseMappings.Add(Keys.D, new PlayerStopMoveRightCommand(myGame));
			onReleaseMappings.Add(Keys.S, new PlayerStopMoveDownCommand(myGame));
			onReleaseMappings.Add(Keys.A, new PlayerStopMoveLeftCommand(myGame));
		}

		public void Update()
		{
			currentState = Keyboard.GetState();

			// On key press
			foreach (Keys key in currentState.GetPressedKeys())
			{
				if(onPressMappings.ContainsKey(key) && !oldState.IsKeyDown(key))
				{
					onPressMappings[key].Execute();
				}
			}

			// On key release
			foreach(Keys key in oldState.GetPressedKeys())
            {
				if (onReleaseMappings.ContainsKey(key) && !currentState.IsKeyDown(key))
                {
					onReleaseMappings[key].Execute();
                }
            }

			oldState = Keyboard.GetState();
		}
	}
}
