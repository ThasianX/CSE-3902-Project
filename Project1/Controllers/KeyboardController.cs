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
        private IPlayer player;

		public KeyboardController(Game1 game)
		{
			myGame = game;
            onPressMappings = new Dictionary<Keys, ICommand>();
			onReleaseMappings = new Dictionary<Keys, ICommand>();
            oldState = Keyboard.GetState();
		}

        public void RegisterPlayer(IPlayer player) 
		{
			this.player = player;
        }

        public void ClearData()
        {
            onPressMappings.Clear();
            onReleaseMappings.Clear();
        }

		public void RegisterCommands()
		{
			// COMMANDS THAT EXECUTE ON PRESS =============================================

			// Player 
			onPressMappings.Add(Keys.Up, new PlayerFaceUpCommand(player));
			onPressMappings.Add(Keys.Right, new PlayerFaceRightCommand(player));
			onPressMappings.Add(Keys.Down, new PlayerFaceDownCommand(player));
			onPressMappings.Add(Keys.Left, new PlayerFaceLeftCommand(player));

			onPressMappings.Add(Keys.W, new PlayerMoveUpCommand(player));
			onPressMappings.Add(Keys.D, new PlayerMoveRightCommand(player));
			onPressMappings.Add(Keys.S, new PlayerMoveDownCommand(player));
			onPressMappings.Add(Keys.A, new PlayerMoveLeftCommand(player));

			// For Debugging
			//onPressMappings.Add(Keys.Z, new PlayerSwordAttackCommand(player));
			//onPressMappings.Add(Keys.N, new PlayerSwordAttackCommand(player));
			//onPressMappings.Add(Keys.D1, new PlayerBoomerangAttackCommand(player));
			//onPressMappings.Add(Keys.D2, new PlayerShootArrowCommand(player));
			//onPressMappings.Add(Keys.D3, new PlayerBombAttackCommand(player));
			//onPressMappings.Add(Keys.D4, new PlayerShootBulletCommand(player));
			//onPressMappings.Add(Keys.I, new PlayerShowCollectionCommand(player));
			//onPressMappings.Add(Keys.E, new PlayerTakeDamageCommand(player, 5));

			onPressMappings.Add(Keys.Space, new PlayerUsePrimaryCommand(player));
			onPressMappings.Add(Keys.LeftShift, new PlayerUseSecondaryCommand(player));
			onPressMappings.Add(Keys.LeftControl, new PlayerBombAttackCommand(player));

			// COMMANDS THAT EXECUTE ON RELEASE

			// Player
			onReleaseMappings.Add(Keys.W, new PlayerStopMoveUpCommand(player));
			onReleaseMappings.Add(Keys.D, new PlayerStopMoveRightCommand(player));
			onReleaseMappings.Add(Keys.S, new PlayerStopMoveDownCommand(player));
			onReleaseMappings.Add(Keys.A, new PlayerStopMoveLeftCommand(player));

			onReleaseMappings.Add(Keys.Right, new SelectNextCommand());
			onReleaseMappings.Add(Keys.Left, new SelectPreviousCommand());
			onReleaseMappings.Add(Keys.Space, new EquipPrimaryCommand(myGame));
			onReleaseMappings.Add(Keys.LeftShift, new EquipSecondaryCommand(myGame));

			onPressMappings.Add(Keys.D0, new QuitCommand(myGame));
			onReleaseMappings.Add(Keys.Q, new QuitCommand(myGame));
			onReleaseMappings.Add(Keys.R, new ResetCommand(myGame));
			onReleaseMappings.Add(Keys.Tab, new PauseCommand(myGame));
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

		public void UpdateOnRelease()
        {
			currentState = Keyboard.GetState();

			// On key release
			foreach (Keys key in oldState.GetPressedKeys())
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
//Team JellyLake Autumn 2021
