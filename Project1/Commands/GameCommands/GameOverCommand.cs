using Project1.GameStates;
using Project1.Interfaces;

namespace Project1.Commands
{
    class GameOverCommand : ICommand
    {
        private readonly Game1 myGame;

        public GameOverCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.gameState = new GameOverState(myGame);
        }
    }
}
