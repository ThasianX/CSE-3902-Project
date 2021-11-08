using Project1.Interfaces;

namespace Project1.Commands
{
    class PauseCommand: ICommand
    {
        private readonly Game1 myGame;

        public PauseCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.gameState.Pause();
        }
    }
}
