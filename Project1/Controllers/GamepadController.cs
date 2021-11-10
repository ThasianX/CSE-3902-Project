using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Interfaces;

namespace Project1
{
    class GamepadController: IController
	{
		private readonly Game1 myGame;
		private Player myPlayer;

		public GamepadController(Game1 game, Player player)
		{
			myGame = game;
			myPlayer = player;
		}

        public void ClearData()
        {
        }

		public void RegisterPlayer(IPlayer player) 
		{
		}

		public void RegisterCommands() 
		{
		}

		public void Update()
		{
			GamePadState newState = GamePad.GetState(Microsoft.Xna.Framework.PlayerIndex.One);

			if (newState.ThumbSticks.Left.Y > 0.5)
				new PlayerMoveUpCommand(myPlayer).Execute();
			if (newState.ThumbSticks.Left.Y < -0.5)
				new PlayerMoveDownCommand(myPlayer).Execute();
			if (newState.ThumbSticks.Left.X > 0.5)
				new PlayerMoveRightCommand(myPlayer).Execute();
			if (newState.ThumbSticks.Left.X < -0.5)
				new PlayerMoveLeftCommand(myPlayer).Execute();
			if (newState.IsButtonDown(Buttons.DPadUp))
				new PlayerFaceUpCommand(myPlayer).Execute();
			if (newState.IsButtonDown(Buttons.DPadDown))
				new PlayerFaceDownCommand(myPlayer).Execute();
			if (newState.IsButtonDown(Buttons.DPadRight))
				new PlayerFaceRightCommand(myPlayer).Execute();
			if (newState.IsButtonDown(Buttons.DPadLeft))
				new PlayerFaceLeftCommand(myPlayer).Execute();
		}
		public void UpdateOnRelease()
        {
        }
    }
}
