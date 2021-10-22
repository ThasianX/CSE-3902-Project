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
		private readonly Player myPlayer;
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
			onPressMappings.Add(Keys.Up, new PlayerFaceUpCommand(myPlayer));
			onPressMappings.Add(Keys.Right, new PlayerFaceRightCommand(myPlayer));
			onPressMappings.Add(Keys.Down, new PlayerFaceDownCommand(myPlayer));
			onPressMappings.Add(Keys.Left, new PlayerFaceLeftCommand(myPlayer));

			onPressMappings.Add(Keys.W, new PlayerMoveUpCommand(myPlayer));
			onPressMappings.Add(Keys.D, new PlayerMoveRightCommand(myPlayer));
			onPressMappings.Add(Keys.S, new PlayerMoveDownCommand(myPlayer));
			onPressMappings.Add(Keys.A, new PlayerMoveLeftCommand(myPlayer));

			onPressMappings.Add(Keys.Z, new PlayerSwordAttackCommand(myPlayer));
			onPressMappings.Add(Keys.N, new PlayerSwordAttackCommand(myPlayer));
			onPressMappings.Add(Keys.D1, new PlayerBoomerangAttackCommand(myPlayer));
			onPressMappings.Add(Keys.D2, new PlayerShootArrowCommand(myPlayer));
			onPressMappings.Add(Keys.D3, new PlayerBombAttackCommand(myPlayer));

			// COMMANDS THAT EXECUTE ON RELEASE

			// Player
			onReleaseMappings.Add(Keys.W, new PlayerStopMoveUpCommand(myPlayer));
			onReleaseMappings.Add(Keys.D, new PlayerStopMoveRightCommand(myPlayer));
			onReleaseMappings.Add(Keys.S, new PlayerStopMoveDownCommand(myPlayer));
			onReleaseMappings.Add(Keys.A, new PlayerStopMoveLeftCommand(myPlayer));

			onReleaseMappings.Add(Keys.E, new PlayerTakeDamageCommand(myPlayer,5));

			onReleaseMappings.Add(Keys.Q, new QuitCommand(myGame));
			onReleaseMappings.Add(Keys.R, new ResetCommand(myGame));
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
