using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using Project1.Commands;
using Project1.Interfaces;
using Project1.PlayerStates;

namespace Project1.Controllers
{
    class MouseController: IController
	{
		private readonly Game1 myGame;
		private MouseState previousState;


		public MouseController(Game1 game)
		{
			myGame = game;
		}

		public void RegisterCommands() 
		{
		}

		public void RegisterPlayer(IPlayer player) 
		{
		}

		public void Update()
		{
			MouseState mouseState = Mouse.GetState();
			if(previousState == null) {
				previousState = mouseState;
			}

			if (mouseState.RightButton == ButtonState.Released && previousState.RightButton == ButtonState.Pressed)
			{
				myGame.levelManager.IncrementRoom();
			} else if (mouseState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
			{
				myGame.levelManager.DecrementRoom();
			}
			previousState = mouseState;
		}
	}
}
