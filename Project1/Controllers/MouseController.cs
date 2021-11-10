using Microsoft.Xna.Framework.Input;
using Project1.Interfaces;
using Project1.Levels;

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

        public void ClearData()
        {
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
				LevelManager.Instance.IncrementRoom();
			} else if (mouseState.LeftButton == ButtonState.Released && previousState.LeftButton == ButtonState.Pressed)
			{
				LevelManager.Instance.DecrementRoom();
			}
			previousState = mouseState;
		}
		public void UpdateOnRelease()
		{
		}
	}
}
