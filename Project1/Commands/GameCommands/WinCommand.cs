using Project1.GameStates;
using Project1.Interfaces;

namespace Project1.Commands
{
    class WinCommand : ICommand
    {
        private readonly Game1 myGame;

        public WinCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            SoundManager.Instance.PlaySound("Fanfare");
            myGame.gameState = new GameWinState(myGame);
        }
    }
}
